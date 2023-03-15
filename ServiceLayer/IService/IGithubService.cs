namespace ServiceLayer;
public interface IGithubService
{
    Task<GitFolderDTO> CreateGitRepositoryFromURLAsync(string url);

    Task<GitFolderDTO> CreateGitRepositoryFromURLAsync(string url, string tokenAuth);

    Task<GitFolderDTO> CreateGitRepositoryFromURLAsync(string url, string username, string password);

    Task<GitFolderDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner);

    Task<GitFolderDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string tokenAuth);

    Task<GitFolderDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string username, string password);

    void AddToGithubActions(string url, string tokenAuth);

}