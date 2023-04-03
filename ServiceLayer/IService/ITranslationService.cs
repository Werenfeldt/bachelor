namespace ServiceLayer;

public interface ITranslationService
{
    Task<string> translateTestfile(string prompt, TestFileDTO testFile);
}