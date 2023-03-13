using Domain.Repositories;

namespace Infrastructure.Repositories;

public sealed class RepoManager : IRepoManager
{
    private readonly Lazy<IScriptRepository> _lazyScriptRepository;

    public RepoManager(RepoDbContext dbContext)
    {
        _lazyScriptRepository = new Lazy<IScriptRepository>(() => new ScriptRepository(dbContext));
    }

    public IScriptRepository ScriptRepository => _lazyScriptRepository.Value;
}