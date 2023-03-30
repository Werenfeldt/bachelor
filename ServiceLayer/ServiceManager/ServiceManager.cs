using OpenAI.GPT3.Interfaces;
namespace ServiceLayer;
public sealed class ServiceManager : IServiceManager
{
    //TODO Move into TranslationService
    //private readonly Lazy<IOpenAIIntegration> _lazyOpenAIIntegration;

    private readonly Lazy<ILoginService> _lazyLoginService;

    private readonly Lazy<IProjectService> _lazyProjectService;

    public ServiceManager(IRepoManager repoManager, IOpenAIService openAiIntegration)
    {
        //_lazyOpenAIIntegration = new Lazy<IOpenAIIntegration>(() => new OpenAIIntegration(openAiIntegration));
        _lazyLoginService = new Lazy<ILoginService>(() => new LoginService(repoManager));
        _lazyProjectService = new Lazy<IProjectService>(() => new ProjectService(repoManager));
    }

    //public IOpenAIIntegration OpenAIIntegration => _lazyOpenAIIntegration.Value;

    public ILoginService LoginService => _lazyLoginService.Value;
    public IProjectService ProjectService => _lazyProjectService.Value;
}
