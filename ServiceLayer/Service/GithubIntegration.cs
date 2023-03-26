namespace ServiceLayer;
using Octokit;
internal sealed class GithubIntegration : IGithubIntegration
{
    private readonly IRepoManager _repoManager;

    private GitHubClient gitHub;

    public GithubIntegration(IRepoManager repoManager)
    {
        _repoManager = repoManager;
        gitHub = new GitHubClient(new ProductHeaderValue("Client"));
    }

    public async Task<ProjectDTO> CreateGitRepositoryFromURLAsync(string url) =>
        await CreateGitRepositoryFromUrl(url);

    public async Task<ProjectDTO> CreateGitRepositoryFromURLAsync(string url, string tokenAuth)
    {
        gitHub.Credentials = new Credentials(tokenAuth);

        return await CreateGitRepositoryFromUrl(url);
    }

    public async Task<ProjectDTO> CreateGitRepositoryFromURLAsync(string url, string username, string password)
    {
        gitHub.Credentials = new Credentials(username, password);

        return await CreateGitRepositoryFromUrl(url);
    }

    public async Task<ProjectDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner) =>
        await CreateGitRepository(repositoryName, repositoryOwner);

    public async Task<ProjectDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string tokenAuth)
    {
        gitHub.Credentials = new Credentials(tokenAuth);

        return await CreateGitRepository(repositoryName, repositoryOwner);
    }

    public async Task<ProjectDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string username, string password)
    {
        //var gitHub = new GitHubClient(new ProductHeaderValue("Client"));
        gitHub.Credentials = new Credentials(username, password);

        return await CreateGitRepository(repositoryName, repositoryOwner);
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
    private async Task<ProjectDTO> CreateGitRepositoryFromUrl(string url)
    {
        var splittedString = StripPrefix(url.Trim(), "https://github.com/").Split('/');
        var repositoryOwner = splittedString[0];
        var repositoryName = splittedString[1];

        return await CreateGitRepository(repositoryName, repositoryOwner);
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

    private async Task<List<CreateTestFileDTO>> makeTestFileDTO(string owner, string name, IReadOnlyList<SearchCode> project)
    {
        List<CreateTestFileDTO> result = new List<CreateTestFileDTO>();

        foreach (var testFile in project)
        {
            var fileContent = await gitHub.Repository.Content.GetAllContents(owner, name, testFile.Path);
            //TODO fix this project null
            CreateTestFileDTO file  = new CreateTestFileDTO
            {
                Name = testFile.Name,
                Path = testFile.Path,
                Content = fileContent[0].Content,
                CreatedDate = DateTime.UtcNow,
                Project = null
            };

            result.Add(file);
        }

        return result;
    }

    public void printFiles(List<TestFileDTO> testFiles)
    {
        foreach (var item in testFiles)
        {
            Console.WriteLine(item.ToString());
        }
    }

}
