using OpenAI.GPT3.Interfaces;
namespace ServiceLayer;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IScriptService> _lazyScriptService;
    private readonly Lazy<IGithubService> _lazyGithubService;

    public ServiceManager(IRepoManager repoManager, IOpenAIService openAiService)
    {
        _lazyScriptService = new Lazy<IScriptService>(() => new ScriptService(repoManager, openAiService));
        _lazyGithubService = new Lazy<IGithubService>(() => new GithubService(repoManager));
    }

    public IScriptService ScriptService => _lazyScriptService.Value;

    public IGithubService GithubService => _lazyGithubService.Value;
}
