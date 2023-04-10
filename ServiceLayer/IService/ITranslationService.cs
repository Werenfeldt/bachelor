namespace ServiceLayer;

public interface ITranslationService
{
    Task<DocumentationDTO> TranslateTestfile(TestFileDTO testFile, string prompt = "Translate the following cypress script into steps in natural language: ");
    Task<Response> UpdateDocumentation(UpdateDocumentationDTO documentation);
}