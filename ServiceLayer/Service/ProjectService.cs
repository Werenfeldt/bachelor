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
    public Task<ProjectDTO> CreateProjectAsync(string url)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectDTO> CreateProjectAsync(string url, string tokenAuth)
    {
        GithubIntegration.SetCredentials(tokenAuth);

        return sendRequest(url);
    }

    public Task<ProjectDTO> CreateProjectAsync(string url, string username, string password)
    {
        GithubIntegration.SetCredentials(username, password);

        return sendRequest(url);
    }

    private Task<ProjectDTO> sendRequest(string url)
    {
        var response = GithubIntegration.Request(url);
        
        var projectDTO = new CreateProjectDTO
        {
            Title = repositoryName,
            GitRepoOwner = repositoryOwner,
            GitRepoName = repositoryName,
            CreatedDate = DateTime.UtcNow
        };
        return await _repoManager.ProjectRepository.Insert(projectDTO);
    }
    private IGithubIntegration GithubIntegration => _lazyGithubIntegration.Value;
}