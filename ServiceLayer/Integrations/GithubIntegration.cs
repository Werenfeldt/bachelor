namespace ServiceLayer;
using Octokit;
using Octokit.Internal;
using Octokit.Reactive;


internal sealed class GithubIntegration : IGithubIntegration
{
    private GitHubClient? gitHub;
    public GithubIntegration()
    {
    }

    public void SetCredentials(string tokenAuth)
    {
        var credentials = new InMemoryCredentialStore(new Credentials(tokenAuth));
        SetUpClient(credentials);
    }
    public async Task<IReadOnlyList<RepositoryContent>> Request(string url)
    {
        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];

        var repository = await gitHub.Repository.Get(repositoryOwner, repositoryName);
        var defaultBranchName = repository.DefaultBranch;
        var treeResponse = await gitHub.Git.Tree.GetRecursive(repositoryOwner, repositoryName, defaultBranchName);

        List<RepositoryContent> content = new List<RepositoryContent>();

        foreach (var item in treeResponse.Tree)
        {
            if (item.Type == TreeType.Blob && item.Path.Contains(".cy"))
            {
                var listOfContent = await gitHub.Repository.Content.GetAllContents(repositoryOwner, repositoryName, item.Path);
                content.Add(listOfContent[0]);
            }
        }

        return content;
    }

    private void SetUpClient(InMemoryCredentialStore credentials)
    {
        gitHub = new GitHubClient(new ProductHeaderValue("Client"), credentials);
    }
    private string StripPrefix(string text, string prefix)
    {
        return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
    }

}
