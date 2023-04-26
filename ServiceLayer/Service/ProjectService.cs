namespace ServiceLayer;

public class ProjectService : IProjectService
{
    private readonly Lazy<IGithubIntegration> _lazyGithubIntegration;

    private readonly IRepoManager _repoManager;

    public ProjectService(IRepoManager repoManager)
    {
        _lazyGithubIntegration = new Lazy<IGithubIntegration>(() => new GithubIntegration());
        _repoManager = repoManager;
    }

    public Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO projectDTO, string tokenAuth)
    {
        GithubIntegration.SetCredentials(tokenAuth);
        return sendRequest(projectDTO);
    }

    public async Task<List<ProjectDTO>> LoadProjectsAsync(Guid userId)
    {
        var projects = await _repoManager.ProjectRepository.ReadAllProjectsByUserIdAsync(userId);
        return projects.ToList();
    }

    public async Task<List<TestFileDTO>> LoadTestFilesForProjectAsync(Guid projectId)
    {
        var testFiles = await _repoManager.TestFileRepository.ReadAllTestFilesByProjectIdAsync(projectId);
        return testFiles.ToList();
    }

    public async Task<TestFileDTO> LoadTestFileByIdAsync(Guid testFileId)
    {
        var testFile = await _repoManager.TestFileRepository.ReadTestFileByIdAsync(testFileId);

        if (testFile.IsSome)
        {
            return testFile;
        }

        throw new TestFileDoesNotExistException("The chosen testfile does not exist, try synchronizing the project.");
    }

    public async Task<DocumentationDTO> LoadDocumentationByTestFilesIdAsync(Guid testFileId)
    {
        var documentation = await _repoManager.DocumentationRepository.ReadDocumentationByTestFileIdAsync(testFileId);

        if (documentation.IsSome)
        {
            return documentation;
        }

        return new DocumentationDTO(Guid.Empty, "", "", Guid.Empty, DateTime.UtcNow, DateTime.UtcNow);
    }

    public async Task<Response> DeleteProject(Guid projectId)
    {
        return await _repoManager.ProjectRepository.DeleteProjectAsync(projectId);
    }

    public async Task<List<ProjectWithTestFilesDTO>> LoadSideBar(Guid userId)
    {
        var projects = await _repoManager.ProjectRepository.ReadAllProjectsWithTestFilesByUserIdAsync(userId);
        return projects.ToList();
    }

    private async Task<ProjectDTO> sendRequest(CreateProjectDTO projectDTO)
    {
        var repositoryContent = await GithubIntegration.Request(projectDTO.GitUrl);

        projectDTO.TestFileToBeCreatedDTOs = GetAllTestFiles(repositoryContent);

        if (projectDTO.TestFileToBeCreatedDTOs.Any())
        {

            return await _repoManager.ProjectRepository.CreateProjectAsync(projectDTO);
        }

        throw new GitHubRequestException("Retrieving the files from Github failed, please try again");
    }

    private List<CreateTestFileDTO> GetAllTestFiles(IReadOnlyList<RepositoryContent> repositoryContent)
    {
        var testList = new List<CreateTestFileDTO>();

        foreach (var item in repositoryContent)
        {
            var testFile = new CreateTestFileDTO
            {
                Name = item.Name,
                Path = item.Path,
                Content = item.Content,
            };
            testList.Add(testFile);
        }
        return testList;
    }
    private IGithubIntegration GithubIntegration => _lazyGithubIntegration.Value;
}