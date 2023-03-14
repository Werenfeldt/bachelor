using Domain.Repositories;
using Services.Interfaces;
using Services.Service;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace Services;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IScriptService> _lazyScriptService;

    public ServiceManager(IRepoManager repoManager, IOpenAIService openAiService)
    {
        _lazyScriptService = new Lazy<IScriptService>(() => new ScriptService(repoManager, openAiService));
    }

    public IScriptService ScriptService => _lazyScriptService.Value;
}
