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

    public async Task<DocumentationDTO> translateTestfile(TestFileDTO testFile, string prompt)
    {
        try
        {
            var input = prompt + testFile.Content;
            var (translation, summary) = await OpenAIIntegration.Request(input);

            var docDTO = new CreateDocumentationDTO
            {
                Summary = summary,
                Translation = translation,
                TestFileId = testFile.Id
            };

            return await _repoManager.DocumentationRepository.CreateDocumentationAsync(docDTO);
        }
        catch (Exception chatGPTException)
        {
            throw chatGPTException;
        }
    }

    public async Task<Response> UpdateSummary(UpdateDocumentationDTO documentation)
    {
        return await _repoManager.DocumentationRepository.UpdateDocumentationAsync(documentation);
    }

    private IOpenAIIntegration OpenAIIntegration => _lazyOpenAIIntegration.Value;
}