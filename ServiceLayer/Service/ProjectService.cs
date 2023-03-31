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
    public Task<ProjectDTO> CreateProjectAsync(Guid userId, string url)
    {
        return sendRequest(userId, url);
    }

    public Task<ProjectDTO> CreateProjectAsync(Guid userId, string url, string tokenAuth)
    {
        GithubIntegration.SetCredentials(tokenAuth);

        return sendRequest(userId, url);
    }

    public Task<ProjectDTO> CreateProjectAsync(Guid userId, string url, string username, string password)
    {
        GithubIntegration.SetCredentials(username, password);

        return sendRequest(userId, url);
    }

    private async Task<ProjectDTO> sendRequest(Guid userId, string url)
    {
        var (gitRepositoryOwner, gitRepositoryName, repositoryContent) = await GithubIntegration.Request(url);

        var listCreateTestFileDTO = GetAllTestFiles(repositoryContent);

        var projectDTO = new CreateProjectDTO
        {
            Title = gitRepositoryName,
            GitRepoOwner = gitRepositoryOwner,
            GitRepoName = gitRepositoryName,
            //CreatedDate = DateTime.UtcNow,
            UserId = userId,
            TestFileToBeCreatedDTOs = listCreateTestFileDTO
        };
        
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
                //CreatedDate = DateTime.UtcNow
            };
            testList.Add(script);
        }
        return testList;
    }
    private IGithubIntegration GithubIntegration => _lazyGithubIntegration.Value;
}