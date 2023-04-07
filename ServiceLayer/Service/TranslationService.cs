using OpenAI.GPT3.Interfaces;
namespace ServiceLayer;

public class TranslationService : ITranslationService
{
    private readonly Lazy<IOpenAIIntegration> _lazyOpenAIIntegration;
    private readonly IRepoManager _repoManager;

    public TranslationService(IRepoManager repoManager, IOpenAIService openAiIntegration)
    {
        _repoManager = repoManager;
        _lazyOpenAIIntegration = new Lazy<IOpenAIIntegration>(() => new OpenAIIntegration(openAiIntegration));
    }

    public async Task<DocumentationDTO> translateTestfile(string prompt, TestFileDTO testFile)
    {
        try
        {
            var input = prompt + testFile.Content;
            Console.WriteLine(input);
            var output = await OpenAIIntegration.Request(input);
            Console.WriteLine(output);
            var splitOutput = output.Split("Summary");

            var docDTO = new CreateDocumentationDTO
            {
                Summary = splitOutput[1],
                Translation = splitOutput[0],
                TestFileId = testFile.Id
            };

            return await _repoManager.DocumentationRepository.CreateDocumentationAsync(docDTO);
        }
        catch (Exception chatGPTException)
        {
            throw chatGPTException;
        }
    }
    private IOpenAIIntegration OpenAIIntegration => _lazyOpenAIIntegration.Value;
}