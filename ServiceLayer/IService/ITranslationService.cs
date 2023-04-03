namespace ServiceLayer;

public interface ITranslationService
{
    Task<DocumentationDTO> translateTestfile(string prompt, TestFileDTO testFile);
}