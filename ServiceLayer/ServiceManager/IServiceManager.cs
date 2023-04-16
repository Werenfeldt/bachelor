namespace ServiceLayer;

public interface IServiceManager
{
    ILoginService LoginService { get; }

    IProjectService ProjectService { get; }

    ITranslationService TranslationService { get; }

    IExportService ExportService { get; }

}