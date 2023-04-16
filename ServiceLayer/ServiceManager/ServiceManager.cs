using OpenAI.GPT3.Interfaces;

namespace ServiceLayer;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ILoginService> _lazyLoginService;

    private readonly Lazy<IProjectService> _lazyProjectService;

    private readonly Lazy<ITranslationService> _lazyTranslationService;

    private readonly Lazy<IExportService> _lazyExportService;

    public ServiceManager(IRepoManager repoManager, IOpenAIService openAiIntegration)
    {
        _lazyLoginService = new Lazy<ILoginService>(() => new LoginService(repoManager));
        _lazyProjectService = new Lazy<IProjectService>(() => new ProjectService(repoManager));
        _lazyTranslationService = new Lazy<ITranslationService>(() => new TranslationService(repoManager, openAiIntegration));
        _lazyExportService = new Lazy<IExportService>(() => new ExportService(repoManager));
    }

    public ILoginService LoginService => _lazyLoginService.Value;
    public IProjectService ProjectService => _lazyProjectService.Value;
    public ITranslationService TranslationService => _lazyTranslationService.Value;
    public IExportService ExportService => _lazyExportService.Value;
}
