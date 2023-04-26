namespace ServiceLayer;
public interface IGithubIntegration
{
    void SetCredentials(string tokenAuth);
    Task<IReadOnlyList<RepositoryContent>> Request(string url);
}