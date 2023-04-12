using Microsoft.JSInterop;
namespace ServiceLayer;
public interface IExportService
{
    void DownloadPDF(IJSRuntime js, string filename = "report.pdf");
}