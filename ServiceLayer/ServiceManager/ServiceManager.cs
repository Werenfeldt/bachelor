using OpenAI.GPT3.Interfaces;
namespace ServiceLayer;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IOpenAIIntegration> _lazyOpenAIIntegration;

    private readonly Lazy<ILoginService> _lazyLoginService;

    public ServiceManager(IRepoManager repoManager, IOpenAIService openAiIntegration)
    {
        _lazyOpenAIIntegration = new Lazy<IOpenAIIntegration>(() => new OpenAIIntegration(openAiIntegration));
        _lazyLoginService = new Lazy<ILoginService>(() => new LoginService(repoManager));
    }

    public IOpenAIIntegration OpenAIIntegration => _lazyOpenAIIntegration.Value;

    public ILoginService LoginService => _lazyLoginService.Value;
}
