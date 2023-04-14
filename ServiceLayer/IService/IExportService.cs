using Microsoft.JSInterop;
namespace ServiceLayer;
public interface IExportService
{
    ValueTask<object> SaveAsPDF(IJSRuntime js, ProjectDTO project, bool includeScript, bool includeTranslation, bool includeSummary);
}