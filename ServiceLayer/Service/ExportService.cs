using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;

namespace ServiceLayer;
public class ExportService : IExportService
{
    private readonly IRepoManager _repoManager;

    public ExportService(IRepoManager repoManager) => _repoManager = repoManager;

    public void DownloadPDF(IJSRuntime js, string filename = "report.pdf")
    {
        js.InvokeVoidAsync("DownloadPdf", filename, Convert.ToBase64String(GenerateReport()));
        Console.WriteLine("BANG BANG");
    }

    private byte[] GenerateReport()
    {
        var memoryStream = new MemoryStream();

        float margeLeft = 1.5f;
        float margeRight = 1.5f;
        float margeTop = 1.5f;
        float margeBottom = 1.5f;

        Document pdf = new Document(
            PageSize.A4,
            margeLeft,
            margeRight,
            margeTop,
            margeBottom
        );

        pdf.AddTitle("Some title");
        pdf.AddAuthor("Some autor");
        pdf.AddCreationDate();
        pdf.AddKeywords("Some keyword");
        pdf.AddSubject("Some subject");


        PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);

        //Create header
        var fontStyle = FontFactory.GetFont("Arial", 16, BaseColor.White);
        var labelHeader = new Chunk("Blazor PDF Header", fontStyle);

        HeaderFooter header = new HeaderFooter(new Phrase(labelHeader), false)
        {
            BackgroundColor = new BaseColor(50, 20, 120),
            Alignment = Element.ALIGN_CENTER,
            Border = Rectangle.NO_BORDER
        };
        pdf.Header = header;

        //Create footer
        var labelFooter = new Chunk("Page", fontStyle);
        HeaderFooter footer = new HeaderFooter(new Phrase(labelFooter), false)
        {
            BackgroundColor = new BaseColor(120, 3, 120),
            Alignment = Element.ALIGN_RIGHT,
            Border = Rectangle.NO_BORDER
        };
        pdf.Footer = footer;

        //Body
        pdf.Open();

        var title = new Paragraph("Blazor PDF Report", new Font(Font.HELVETICA, 20, Font.BOLD));
        title.SpacingAfter = 18f;

        pdf.Add(title);

        Font _fontStyle = FontFactory.GetFont("Tahoma", 12f, Font.NORMAL);
        var myText = "This is the content";
        var phrase = new Phrase(myText, _fontStyle);

        pdf.Close();

        return memoryStream.ToArray();
    }

}