namespace ServiceLayer;
using Octokit;
internal sealed class GithubIntegration : IGithubIntegration
{
    private GitHubClient? gitHub;

    public GithubIntegration() { }

    public void SetCredentials(string tokenAuth)
    {
        SetUpClient();
        //TODO set up try catch
        gitHub.Credentials = new Credentials(tokenAuth);
    }

    public void SetCredentials(string username, string password)
    {
        SetUpClient();
        //TODO set up try catch
        gitHub.Credentials = new Credentials(username, password);
    }

    public async Task<(string GitRepositoryOwner, string GitRepositoryName, IReadOnlyList<RepositoryContent>)> Request(string url)
    {
        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];

        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var result = await gitHub.Search.SearchCode(request);

        List<RepositoryContent> content = new List<RepositoryContent>();

        foreach (var item in result.Items)
        {
            var listOfContent = await gitHub.Repository.Content.GetAllContents(repositoryOwner, repositoryName, item.Path);
            content.Add(listOfContent[0]);
        }

        return (repositoryOwner, repositoryName, content);
    }


    public async void AddToGithubActions(string url, string tokenAuth)
    {
        //TODO update so it doesnt set the credentials again 
        gitHub.Credentials = new Credentials(tokenAuth);

        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];


        string commitMessage = "Created new github actions file";
        string fileName = "builds.yml";
        string fileContent = "I am a message";


        await gitHub.Repository.Content.CreateFile(repositoryOwner, repositoryName, ".github/workflows/" + fileName, new CreateFileRequest(commitMessage, fileContent));
    }

    private void SetUpClient()
    {
        gitHub = new GitHubClient(new ProductHeaderValue("Client"));
    }
    private string StripPrefix(string text, string prefix)
    {
        return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
    }

}
