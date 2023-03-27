using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace ServiceLayer;

internal sealed class OpenAIIntegration : IOpenAIIntegration
{
    private readonly IRepoManager _repoManager;

    private readonly IOpenAIService _openAiService;


    public OpenAIIntegration(IRepoManager repoManager, IOpenAIService openAiService) { 
        _repoManager = repoManager;
        _openAiService = openAiService;}
    
    public async Task<TestFileDTO> CreateAsync(Guid ownerId, CreateTestFileDTO scriptForCreationDto, CancellationToken cancellationToken = default)
    {
        return await _repoManager.TestFileRepository.Insert(scriptForCreationDto);
    }

    public Task DeleteAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TestFileDTO>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TestFileDTO> GetByIdAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Translate(string s)
    {
        var translation = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = new List<ChatMessage>
            {
                ChatMessage.FromUser(s)
            },
            Model = Models.ChatGpt3_5Turbo,
            MaxTokens = 50//optional
        });

        if (translation.Successful)
        {
                return translation.Choices.First().Message.Content;
        }
        
        return "Something went wrong";
    }
}