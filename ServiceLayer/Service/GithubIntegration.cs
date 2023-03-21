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

    public async Task<GitFolderDTO> CreateGitRepositoryFromURLAsync(string url) =>
        await CreateGitRepositoryFromUrl(url);

    public async Task<GitFolderDTO> CreateGitRepositoryFromURLAsync(string url, string tokenAuth)
    {
        gitHub.Credentials = new Credentials(tokenAuth);

        return await CreateGitRepositoryFromUrl(url);
    }

    public async Task<GitFolderDTO> CreateGitRepositoryFromURLAsync(string url, string username, string password)
    {
        gitHub.Credentials = new Credentials(username, password);

        return await CreateGitRepositoryFromUrl(url);
    }

    public async Task<GitFolderDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner) =>
        await CreateGitRepository(repositoryName, repositoryOwner);

    public async Task<GitFolderDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string tokenAuth)
    {
        gitHub.Credentials = new Credentials(tokenAuth);

        return await CreateGitRepository(repositoryName, repositoryOwner);
    }

    public async Task<GitFolderDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string username, string password)
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

    private async Task<GitFolderDTO> CreateGitRepository(string repositoryName, string repositoryOwner)
    {
        RepositoryCollection repos = new RepositoryCollection();
        repos.Add(repositoryOwner, repositoryName);

        var request = new SearchCodeRequest()
        {
            Repos = repos
        };

        var repositoryContents = await gitHub.Search.SearchCode(request);

        var gitFolderDTO = new CreateGitFolderDTO
        {
            Id = Guid.NewGuid(),
            Name = repositoryName,
            OwnerName = repositoryOwner,
            scriptFileDTOs = await makeScriptFileDTO(repositoryOwner, repositoryName, repositoryContents.Items)
        };
        return await _repoManager.GitFolderRepository.Insert(gitFolderDTO);
    }

    private async Task<GitFolderDTO> CreateGitRepositoryFromUrl(string url)
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

        var repositoryContents = await gitHub.Search.SearchCode(request);

        var gitFolderDTO = new CreateGitFolderDTO
        {
            Id = Guid.NewGuid(),
            Name = repositoryName,
            OwnerName = repositoryOwner,
            scriptFileDTOs = await makeScriptFileDTO(repositoryOwner, repositoryName, repositoryContents.Items)
        };

        return await _repoManager.GitFolderRepository.Insert(gitFolderDTO);
    }
    private static string StripPrefix(string text, string prefix)
    {
        return text.StartsWith(prefix) ? text.Substring(prefix.Length) : text;
    }

    private async Task<List<ScriptFileDTO>> makeScriptFileDTO(string owner, string name, IReadOnlyList<SearchCode> GitFolderDTO)
    {
        List<ScriptFileDTO> result = new List<ScriptFileDTO>();

        foreach (var scriptFile in GitFolderDTO)
        {
            var fileContent = await gitHub.Repository.Content.GetAllContents(owner, name, scriptFile.Path);

            ScriptFileDTO file = new ScriptFileDTO(
                Guid.NewGuid(),
                DateTime.UtcNow,
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

    public void printFiles(List<ScriptFileDTO> scriptFiles)
    {
        foreach (var item in scriptFiles)
        {
            Console.WriteLine(item.ToString());
        }
    }

}
