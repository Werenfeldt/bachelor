namespace ServiceLayer;
public interface IGithubIntegration
{
    Task<ProjectDTO> CreateGitRepositoryFromURLAsync(string url);

    Task<ProjectDTO> CreateGitRepositoryFromURLAsync(string url, string tokenAuth);

    Task<ProjectDTO> CreateGitRepositoryFromURLAsync(string url, string username, string password);

    Task<ProjectDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner);

    Task<ProjectDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string tokenAuth);

    Task<ProjectDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string username, string password);

    void AddToGithubActions(string url, string tokenAuth);

}