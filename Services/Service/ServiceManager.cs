using Domain.Repositories;
using Services.Interfaces;
using Services.Service;

namespace Services;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IScriptService> _lazyScriptService;

    public ServiceManager(IRepoManager repoManager)
    {
        _lazyScriptService = new Lazy<IScriptService>(() => new ScriptService(repoManager));
    }

    public IScriptService ScriptService => _lazyScriptService.Value;
}
