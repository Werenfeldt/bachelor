using OpenAI.GPT3.Interfaces;
namespace ServiceLayer;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IScriptService> _lazyScriptService;

    public ServiceManager(IRepoManager repoManager, IOpenAIService openAiService)
    {
        _lazyScriptService = new Lazy<IScriptService>(() => new ScriptService(repoManager, openAiService));
    }

    public IScriptService ScriptService => _lazyScriptService.Value;
}
