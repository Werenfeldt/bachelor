namespace ServiceLayer;
public interface IGithubIntegration
{
    void SetCredentials(string tokenAuth);

    void SetCredentials(string username, string password);
    
    Task<(string GitRepositoryOwner, string GitRepositoryName, IReadOnlyList<RepositoryContent>)> Request(string url);
    void AddToGithubActions(string url, string tokenAuth);

}