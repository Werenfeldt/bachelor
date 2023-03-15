namespace RepositoryLayer;

public sealed class RepoManager : IRepoManager
{
    private readonly Lazy<IScriptFileRepository> _lazyScriptFileRepository;

    private readonly Lazy<IGitFolderRepository> _lazyGitFolderRepository;

    public RepoManager(BachelorDbContext dbContext)
    {
        _lazyScriptFileRepository = new Lazy<IScriptFileRepository>(() => new ScriptFileRepository(dbContext));
        _lazyGitFolderRepository = new Lazy<IGitFolderRepository>(() => new GitFolderRepository(dbContext));
    }

    public IScriptFileRepository ScriptFileRepository => _lazyScriptFileRepository.Value;

    public IGitFolderRepository GitFolderRepository => _lazyGitFolderRepository.Value;
}