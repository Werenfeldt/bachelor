using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;

namespace ServiceLayer;
public class ExportService : IExportService
{
    private readonly IRepoManager _repoManager;

    public ExportService(IRepoManager repoManager) => _repoManager = repoManager;

    public async ValueTask<object> SaveAsPDF(IJSRuntime js, ProjectDTO project, bool includeScript, bool includeTranslation, bool includeSummary)
    {
        var pdf = await GeneratePDFAsync(project, includeScript, includeTranslation, includeSummary);
        string filename = project.title + ".pdf";
        var s = await SaveAs(js, filename, pdf);
        return s;
    }

    private async Task<byte[]> GeneratePDFAsync(ProjectDTO project, bool includeScript, bool includeTranslation, bool includeSummary)
    {
        var memoryStream = new MemoryStream();

        float margeLeft = 1.5f;
        float margeRight = 1.5f;
        float margeTop = 1.5f;
        float margeBottom = 1.5f;

        Document pdf = new Document(
            PageSize.A4,
            margeLeft.ToDPI(),
            margeRight.ToDPI(),
            margeTop.ToDPI(),
            margeBottom.ToDPI()
        );

        pdf.AddTitle("Some title");
        pdf.AddAuthor("Some autor");
        pdf.AddCreationDate();
        pdf.AddKeywords("Some keyword");
        pdf.AddSubject("Some subject");


        PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);

        pdf.Open();

        var projectFiles = await _repoManager.TestFileRepository.ReadAllTestFilesByProjectIdAsync(project.Id);

        Console.WriteLine("BIIII");

        foreach (var item in FontFactory.RegisteredFonts)
        {
            Console.WriteLine(item);
        }

        //Fonts
        Font sectionHeaderFont = new Font(Font.HELVETICA, 20, Font.UNDERLINE | Font.BOLD);
        Font sectionTitleFont = new Font(Font.HELVETICA, 12, Font.BOLD);
        Font sectionBodyFont = new Font(Font.HELVETICA, 12, Font.NORMAL);
        Font sectionCodeFont = new Font(FontFactory.GetFont("courier", 8, Font.NORMAL));

        //Document Title
        var title = new Paragraph(project.title + " - Documentation", new Font(Font.HELVETICA, 24, Font.BOLD));
        title.Alignment = Element.ALIGN_CENTER;
        title.SpacingAfter = 18f;
        pdf.Add(title);


        //Document table of contents
        //TODO


        //Document content
        foreach (var file in projectFiles)
        {
            pdf.NewPage();
            Paragraph titleParagraph = new Paragraph(new Phrase(file.Name, sectionHeaderFont));
            titleParagraph.Add(Chunk.Newline);
            titleParagraph.Alignment = Element.ALIGN_CENTER;
            pdf.Add(titleParagraph);

            if (includeScript)
            {
                Paragraph scriptParagraph = new Paragraph();
                scriptParagraph.Add(new Phrase("Script content: ", sectionTitleFont));
                scriptParagraph.Add(Chunk.Newline);
                scriptParagraph.Add(new Phrase(file.Content, sectionCodeFont));
                scriptParagraph.Add(Chunk.Newline);
                pdf.Add(scriptParagraph);

            }
            if (includeSummary)
            {
                Paragraph summaryParagraph = new Paragraph();
                var documentation = await _repoManager.DocumentationRepository.ReadDocumentationByTestFileIdAsync(file.Id);
                if (documentation.IsSome)
                {
                    summaryParagraph.Add(new Phrase("Test Summary: ", sectionTitleFont));
                    summaryParagraph.Add(Chunk.Newline);
                    summaryParagraph.Add(new Phrase(documentation.Value.Summary, sectionBodyFont));
                    summaryParagraph.Add(Chunk.Newline);
                }
                pdf.Add(summaryParagraph);
            }
            if (includeTranslation)
            {
                Paragraph translationParagraph = new Paragraph();
                var documentation = await _repoManager.DocumentationRepository.ReadDocumentationByTestFileIdAsync(file.Id);
                if (documentation.IsSome)
                {
                    translationParagraph.Add(new Phrase("Translation: ", sectionTitleFont));
                    translationParagraph.Add(Chunk.Newline);
                    translationParagraph.Add(new Phrase(documentation.Value.Translation, sectionBodyFont));
                    translationParagraph.Add(Chunk.Newline);
                }
                pdf.Add(translationParagraph);
            }

        }

        pdf.Close();
        return memoryStream.ToArray();
    }

    private ValueTask<object> SaveAs(IJSRuntime js, string filename, byte[] data)
        => js.InvokeAsync<object>(
            "saveAsFile",
            filename,
            Convert.ToBase64String(data));
}