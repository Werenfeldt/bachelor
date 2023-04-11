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

    public Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO projectDTO)
    {
        return sendRequest(projectDTO);
    }

    public Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO projectDTO, string tokenAuth)
    {
        GithubIntegration.SetCredentials(tokenAuth);
        return sendRequest(projectDTO);
    }

    public Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO projectDTO, string username, string password)
    {
        GithubIntegration.SetCredentials(username, password);

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
        return await _repoManager.TestFileRepository.ReadTestFileByIdAsync(testFileId);
    }

    public async Task<DocumentationDTO> LoadDocumentationByTestFilesIdAsync(Guid testFileId)
    {
        return await _repoManager.DocumentationRepository.ReadDocumentationByTestFileIdAsync(testFileId);
    }

    public async Task<Response> DeleteProject(Guid projectId)
    {
        return await _repoManager.ProjectRepository.DeleteProjectAsync(projectId);
    }

    private async Task<ProjectDTO> sendRequest(CreateProjectDTO projectDTO)
    {
        var repositoryContent = await GithubIntegration.Request(projectDTO.GitUrl);

        projectDTO.TestFileToBeCreatedDTOs = GetAllTestFiles(repositoryContent);

        return await _repoManager.ProjectRepository.CreateProjectAsync(projectDTO);
    }

    private List<CreateTestFileDTO> GetAllTestFiles(IReadOnlyList<RepositoryContent> repositoryContent)
    {
        var testList = new List<CreateTestFileDTO>();

        foreach (var item in repositoryContent)
        {
            var script = new CreateTestFileDTO
            {
                Name = item.Name,
                Path = item.Path,
                Content = item.Content,
            };
            testList.Add(script);
        }
        return testList;
    }
    private IGithubIntegration GithubIntegration => _lazyGithubIntegration.Value;
}