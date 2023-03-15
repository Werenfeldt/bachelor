namespace ServiceLayer;
using Octokit;
internal sealed class GithubService : IGithubService
{
    private readonly IRepoManager _repoManager;

    public GithubService(IRepoManager repoManager)
    {
        _repoManager = repoManager;
    }

    public async Task<GitFolderDTO> CreateGitRepositoryFromURLAsync(string url)
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

        var gitFolderDTO = new CreateGitFolderDTO
        {
            Id = Guid.NewGuid(),
            Name = repositoryName,
            Owner = repositoryOwner,
            scriptFileDTOs = await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items)
        };
    
        return await _repoManager.GitFolderRepository.Insert(gitFolderDTO);
    }

    public async Task<GitFolderDTO> CreateGitRepositoryFromURLAsync(string url, string tokenAuth)
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
        var gitFolderDTO = new CreateGitFolderDTO
        {
            Id = Guid.NewGuid(),
            Name = repositoryName,
            Owner = repositoryOwner,
            scriptFileDTOs = await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items)
        };

        // TODO ændre tilbage til DB
        return new GitFolderDTO(gitFolderDTO.Id, gitFolderDTO.Owner, gitFolderDTO.Name, gitFolderDTO.scriptFileDTOs);
        //return await _repoManager.GitFolderRepository.Insert(gitFolderDTO);
    }

    public async Task<GitFolderDTO> CreateGitRepositoryFromURLAsync(string url, string username, string password)
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

        var gitFolderDTO = new CreateGitFolderDTO
        {
            Id = Guid.NewGuid(),
            Name = repositoryName,
            Owner = repositoryOwner,
            scriptFileDTOs = await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items)
        };
        return await _repoManager.GitFolderRepository.Insert(gitFolderDTO);
    }

    public async Task<GitFolderDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner)
    {
        var gitHub = new GitHubClient(new ProductHeaderValue("Client"));

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
            Owner = repositoryOwner,
            scriptFileDTOs = await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items)
        };
        return await _repoManager.GitFolderRepository.Insert(gitFolderDTO);
    }

    public async Task<GitFolderDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string tokenAuth)
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

        var gitFolderDTO = new CreateGitFolderDTO
        {
            Id = Guid.NewGuid(),
            Name = repositoryName,
            Owner = repositoryOwner,
            scriptFileDTOs = await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items)
        };
        return await _repoManager.GitFolderRepository.Insert(gitFolderDTO);
    }

    public async Task<GitFolderDTO> CreateGitRepositoryAsync(string repositoryName, string repositoryOwner, string username, string password)
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

        var gitFolderDTO = new CreateGitFolderDTO
        {
            Id = Guid.NewGuid(),
            Name = repositoryName,
            Owner = repositoryOwner,
            scriptFileDTOs = await getFilesAsync(gitHub, repositoryOwner, repositoryName, repositoryContents.Items)
        };
        return await _repoManager.GitFolderRepository.Insert(gitFolderDTO);
    }

    public async void AddToGithubActions(string url, string tokenAuth)
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

    private async Task<List<ScriptFileDTO>> getFilesAsync(GitHubClient gitHub, string owner, string name, IReadOnlyList<SearchCode> GitFolderDTO)
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
