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
        //TODO set up try catch
        var credentials = new InMemoryCredentialStore(new Credentials(tokenAuth));
        SetUpClient(credentials);
    }

    public void SetCredentials(string username, string password)
    {
        //TODO set up try catch
        var credentials = new InMemoryCredentialStore(new Credentials(username, password));
        SetUpClient(credentials);
    }

    public async Task<IReadOnlyList<RepositoryContent>> Request(string url)
    {
        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];

        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos,
            FileName = ".cy"
        };

        var result = await gitHub.Search.SearchCode(request);

        List<RepositoryContent> content = new List<RepositoryContent>();

        foreach (var item in result.Items)
        {
            var listOfContent = await gitHub.Repository.Content.GetAllContents(repositoryOwner, repositoryName, item.Path);
            content.Add(listOfContent[0]);
        }

        return content;
    }


    // public async void AddToGithubActions(string url, string tokenAuth)
    // {
    //     //TODO update so it doesnt set the credentials again 
    //     gitHub.Credentials = new Credentials(tokenAuth);

    //     var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
    //     var repositoryOwner = splittedString[0];
    //     var repositoryName = splittedString[1];


    //     string commitMessage = "Created new github actions file";
    //     string fileName = "builds.yml";
    //     string fileContent = "I am a message";


    //     await gitHub.Repository.Content.CreateFile(repositoryOwner, repositoryName, ".github/workflows/" + fileName, new CreateFileRequest(commitMessage, fileContent));
    // }

    private void SetUpClient(InMemoryCredentialStore credentials)
    {
        gitHub = new GitHubClient(new ProductHeaderValue("Client"), credentials);
    }
    private string StripPrefix(string text, string prefix)
    {
        return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
    }

}
