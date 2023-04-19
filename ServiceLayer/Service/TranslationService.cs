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

    public async Task<DocumentationDTO> TranslateTestfile(TestFileDTO testFile, string prompt)
    {
        try
        {
            var input = prompt + testFile.Content;
            var (translation, summary) = await OpenAIIntegration.Request(input);

            var existingDoc = await _repoManager.DocumentationRepository.ReadDocumentationByTestFileIdAsync(testFile.Id);

            if (existingDoc.IsSome)
            {
                var updateDocDTO = new UpdateDocumentationDTO
                {
                    Id = existingDoc.Value.Id,
                    Summary = summary,
                    Translation = translation,
                    TestFileId = testFile.Id
                };

                await UpdateDocumentation(updateDocDTO);

                var updatedDoc = await _repoManager.DocumentationRepository.ReadDocumentationByTestFileIdAsync(testFile.Id);

                return updatedDoc.Value;

            }
            else
            {
                var docDTO = new CreateDocumentationDTO
                {
                    Summary = summary,
                    Translation = translation,
                    TestFileId = testFile.Id
                };

                return await CreateDocumentation(docDTO);
            }

        }
        catch (Exception chatGPTException)
        {
            throw chatGPTException;
        }
    }

    private async Task<DocumentationDTO> CreateDocumentation(CreateDocumentationDTO createDocumentationDTO)
    {
        return await _repoManager.DocumentationRepository.CreateDocumentationAsync(createDocumentationDTO);
    }

    public async Task<Response> UpdateDocumentation(UpdateDocumentationDTO documentation)
    {
        return await _repoManager.DocumentationRepository.UpdateDocumentationAsync(documentation);
    }

    private IOpenAIIntegration OpenAIIntegration => _lazyOpenAIIntegration.Value;
}