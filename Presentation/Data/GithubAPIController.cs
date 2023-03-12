namespace Presentation.Data;
using Octokit;
public static class GithubAPIController
{

    public static async Task<GithubRepository> GetRepositoryFromURLAsync(string url)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));

        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];

        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var repositoryContents = await gitHub.Search.SearchCode(request);


        return new GithubRepository(repositoryName, repositoryOwner, repositoryContents.Items);
    }

    public static async Task<GithubRepository> GetRepositoryFromURLAsync(string url, string tokenAuth)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));
        gitHub.Credentials = new Credentials(tokenAuth); //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

        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];

        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var repositoryContents = await gitHub.Search.SearchCode(request);

        return new GithubRepository(repositoryName, repositoryOwner, repositoryContents.Items);

    }

    public static async Task<GithubRepository> GetRepositoryFromURLAsync(string url, string username, string password)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));
        gitHub.Credentials = new Credentials(username, password);

        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];

        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var repositoryContents = await gitHub.Search.SearchCode(request);

        return new GithubRepository(repositoryName, repositoryOwner, repositoryContents.Items);

    }

    public static async Task<GithubRepository> GetRepositoryAsync(string repositoryName, string repositoryOwner)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));

        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var repositoryContents = await gitHub.Search.SearchCode(request);

        return new GithubRepository(repositoryName, repositoryOwner, repositoryContents.Items);
    }

    public static async Task<GithubRepository> GetRepositoryAsync(string repositoryName, string repositoryOwner, string tokenAuth)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));
        gitHub.Credentials = new Credentials(tokenAuth); //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

        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var repositoryContents = await gitHub.Search.SearchCode(request);

        return new GithubRepository(repositoryName, repositoryOwner, repositoryContents.Items);
    }

    public static async Task<GithubRepository> GetRepositoryAsync(string repositoryName, string repositoryOwner, string username, string password)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));
        gitHub.Credentials = new Credentials(username, password);

        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var repositoryContents = await gitHub.Search.SearchCode(request);

        return new GithubRepository(repositoryName, repositoryOwner, repositoryContents.Items);
    }


    public static string StripPrefix(string text, string prefix)
    {
        return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
    }
}
