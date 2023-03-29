namespace ServiceLayer;
using Octokit;
internal sealed class GithubIntegration : IGithubIntegration
{
    private GitHubClient? gitHub;

    public GithubIntegration()
    {
    }

    

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

    public async Task<SearchCodeResult> Request(string url)
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

        gitHub.

        return await gitHub.Search.SearchCode(request);
    }

    public async Task<IReadOnlyList<RepositoryContent>> getContent(owner, name, testFile.Path)
    {
        await gitHub.Repository.Content.GetAllContents(owner, name, testFile.Path);
    }

        private async Task<List<IReadOnlyList<RepositoryContent>>> makeTestFileDTO(string owner, string name, IReadOnlyList<SearchCode> project)
    {
        //List<CreateTestFileDTO> result = new List<CreateTestFileDTO>();

        List<IReadOnlyList<RepositoryContent>> result = new List<IReadOnlyList<RepositoryContent>>();

        foreach (var testFile in project)
        {
            
            var fileContent = await gitHub.Repository.Content.GetAllContents(owner, name, testFile.Path);
            //TODO fix this project null
            // CreateTestFileDTO file = new CreateTestFileDTO
            // {
            //     Name = testFile.Name,
            //     Path = testFile.Path,
            //     Content = fileContent[0].Content,
            //     CreatedDate = DateTime.UtcNow,
            //     Project = null
            // };

            result.Add(fileContent);
        }

        return result;
    }

    private void SetUpClient()
    {
        gitHub = new GitHubClient(new ProductHeaderValue("Client"));
    }

    public async void AddToGithubActions(string url, string tokenAuth)
    {
        //var gitHub = new GitHubClient(new ProductHeaderValue("Client"));
        gitHub.Credentials = new Credentials(tokenAuth);

        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];


        string commitMessage = "Created new github actions file";
        string fileName = "builds.yml";
        string fileContent = "I am a message";


        await gitHub.Repository.Content.CreateFile(repositoryOwner, repositoryName, ".github/workflows/" + fileName, new CreateFileRequest(commitMessage, fileContent));
    }

    private async Task<ProjectDTO> CreateGitRepository(string repositoryName, string repositoryOwner)
    {
        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var repositoryContents = await gitHub.Search.SearchCode(request);

        var projectDTO = new CreateProjectDTO
        {
            Title = repositoryName,
            GitRepoOwner = repositoryOwner,
            GitRepoName = repositoryName,
            CreatedDate = DateTime.UtcNow
        };
        return await _repoManager.ProjectRepository.Insert(projectDTO);
    }

    private static string StripPrefix(string text, string prefix)
    {
        return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
    }



    public void printFiles(List<TestFileDTO> testFiles)
    {
        foreach (var item in testFiles)
        {
            Console.WriteLine(item.ToString());
        }
    }

}
