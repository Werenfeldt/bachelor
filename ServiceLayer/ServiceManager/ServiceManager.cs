using OpenAI.GPT3.Interfaces;
namespace ServiceLayer;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IOpenAIIntegration> _lazyOpenAIIntegration;
    private readonly Lazy<IGithubIntegration> _lazyGithubIntegration;

    public ServiceManager(IRepoManager repoManager, IOpenAIService openAiIntegration)
    {
        _lazyOpenAIIntegration = new Lazy<IOpenAIIntegration>(() => new OpenAIIntegration(repoManager, openAiIntegration));
        _lazyGithubIntegration = new Lazy<IGithubIntegration>(() => new GithubIntegration(repoManager));
    }

    public IOpenAIIntegration OpenAIIntegration => _lazyOpenAIIntegration.Value;

    public IGithubIntegration GithubIntegration => _lazyGithubIntegration.Value;
}
