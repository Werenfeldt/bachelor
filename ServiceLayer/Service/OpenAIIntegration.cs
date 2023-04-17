using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace ServiceLayer;

internal sealed class OpenAIIntegration : IOpenAIIntegration
{
    private readonly IOpenAIService _openAiService;

    public OpenAIIntegration(IOpenAIService openAiService) =>
        _openAiService = openAiService;

    public async Task<(string, string)> Request(string s)
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

        Console.WriteLine("Translation of steps is successful: " + translation.Successful.ToString());

        if (translation.Successful)
        {
            var summary = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromUser(s),
                    ChatMessage.FromAssistant(translation.Choices.First().Message.Content),
                    ChatMessage.FromUser("Make a brief summary")
                },
                Model = Models.ChatGpt3_5Turbo,
                MaxTokens = 400
            });
            Console.WriteLine("Translation of summary is successful:" + summary.Successful.ToString());
            if (summary.Successful)
            {
                return (translation.Choices.First().Message.Content, summary.Choices.First().Message.Content);
            }
        }

        return ("Something went wrong", "Something went wrong");
    }


}