namespace ServiceLayer;

public interface ITranslationService
{
    Task<DocumentationDTO> translateTestfile(TestFileDTO testFile, string prompt = "Translate the following cypress script into steps in natural language: ");
}