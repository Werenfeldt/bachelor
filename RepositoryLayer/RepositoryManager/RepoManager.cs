namespace RepositoryLayer;

public sealed class RepoManager : IRepoManager
{
    private readonly Lazy<IScriptRepository> _lazyScriptRepository;

    public RepoManager(BachelorDbContext dbContext)
    {
        _lazyScriptRepository = new Lazy<IScriptRepository>(() => new ScriptRepository(dbContext));
    }

    public IScriptRepository ScriptRepository => _lazyScriptRepository.Value;
}