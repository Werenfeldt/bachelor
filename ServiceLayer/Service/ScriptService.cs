using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using Mapster;

namespace ServiceLayer;

internal sealed class ScriptService : IScriptService
{
    private readonly IRepoManager _repoManager;

    private readonly IOpenAIService _openAiService;


    public ScriptService(IRepoManager repoManager, IOpenAIService openAiService) { 
        _repoManager = repoManager;
        _openAiService = openAiService;}
    
    public async Task<ScriptFileDTO> CreateAsync(Guid ownerId, CreateScriptFileDTO scriptForCreationDto, CancellationToken cancellationToken = default)
    {
        return await _repoManager.ScriptFileRepository.Insert(scriptForCreationDto);
    }

    public Task DeleteAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ScriptFileDTO>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ScriptFileDTO> GetByIdAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken)
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