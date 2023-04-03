namespace ServiceLayer;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ILoginService> _lazyLoginService;

    private readonly Lazy<IProjectService> _lazyProjectService;

    public ServiceManager(IRepoManager repoManager)
    {
        _lazyLoginService = new Lazy<ILoginService>(() => new LoginService(repoManager));
        _lazyProjectService = new Lazy<IProjectService>(() => new ProjectService(repoManager));
    }

    public ILoginService LoginService => _lazyLoginService.Value;
    public IProjectService ProjectService => _lazyProjectService.Value;
}
