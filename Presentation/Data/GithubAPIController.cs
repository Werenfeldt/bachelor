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


        return new GithubRepository(repositoryName, repositoryOwner, await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items));
    }

    public static async Task<GithubRepository> GetRepositoryFromURLAsync(string url, string tokenAuth)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));
        gitHub.Credentials = new Credentials(tokenAuth);

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

        return new GithubRepository(repositoryName, repositoryOwner, await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items));

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

        return new GithubRepository(repositoryName, repositoryOwner, await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items));

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

        return new GithubRepository(repositoryName, repositoryOwner, await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items));
    }

    public static async Task<GithubRepository> GetRepositoryAsync(string repositoryName, string repositoryOwner, string tokenAuth)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));
        gitHub.Credentials = new Credentials(tokenAuth);

        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var repositoryContents = await gitHub.Search.SearchCode(request);

        return new GithubRepository(repositoryName, repositoryOwner, await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items));
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

        return new GithubRepository(repositoryName, repositoryOwner, await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items));
    }

    public static async void AddToGithubActions(string url, string tokenAuth)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));
        gitHub.Credentials = new Credentials(tokenAuth);

        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];


        string commitMessage = "Created new github actions file";
        string fileName = "builds.yml";
        string fileContent = "I am a message";


        await gitHub.Repository.Content.CreateFile(repositoryOwner, repositoryName, ".github/workflows/" + fileName, new CreateFileRequest(commitMessage, fileContent));
    }
    private static string StripPrefix(string text, string prefix)
    {
        return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
    }

    private static async Task<List<ScriptFile>> getFilesAsync(GitHubClient gitHub, string owner, string name, IReadOnlyList<SearchCode> githubRepository)
    {
        List<ScriptFile> result = new List<ScriptFile>();

        foreach (var scriptFile in githubRepository)
        {
            var fileContent = await gitHub.Repository.Content.GetAllContents(owner, name, scriptFile.Path);

            ScriptFile file = new ScriptFile(
                scriptFile.GitUrl,
                scriptFile.HtmlUrl,
                scriptFile.Url,
                scriptFile.Path,
                scriptFile.Name,
                scriptFile.Sha,
                fileContent[0].Content
            );

            result.Add(file);
        }

        return result;
    }

}
