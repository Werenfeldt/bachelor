namespace ServiceLayer;

public interface ITranslationService
{
    Task<DocumentationDTO> TranslateTestfile(TestFileDTO testFile, string prompt = "Translate the following cypress script into steps in natural language such that a QA tester can execute the test case in a browser: ");
    Task<Response> UpdateDocumentation(UpdateDocumentationDTO documentation);
}