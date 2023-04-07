using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace ServiceLayer;

internal sealed class OpenAIIntegration : IOpenAIIntegration
{
    private readonly IOpenAIService _openAiService;

    public OpenAIIntegration(IOpenAIService openAiService) =>
        _openAiService = openAiService;

    public async Task<string> Request(string s)
    {
        var translation = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = new List<ChatMessage>
            {
                ChatMessage.FromUser(s)
            },
            Model = Models.ChatGpt3_5Turbo,
            MaxTokens = 200//optional
        });

        if (translation.Successful)
        {
                return translation.Choices.First().Message.Content;
        }
        
        return "Something went wrong";
    }

    
}