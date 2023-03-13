using Domain.Repositories;
using Services.Interfaces;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace Services.Service;

internal sealed class ScriptService : IScriptService
{
    private readonly IRepoManager _repoManager;

    private IOpenAIService _openAiService;


    public ScriptService(IRepoManager repoManager) => _repoManager = repoManager;
    
    public Task<ScriptDto> CreateAsync(Guid ownerId, CreateScriptDto scriptForCreationDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ScriptDto>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ScriptDto> GetByIdAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken)
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