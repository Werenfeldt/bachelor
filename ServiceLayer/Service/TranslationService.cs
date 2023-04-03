using OpenAI.GPT3.Interfaces;
namespace ServiceLayer;

public class TranslationService : ITranslationService
{
    private readonly Lazy<IOpenAIIntegration> _lazyOpenAIIntegration;
    private readonly IRepoManager _repoManager;
    //prompt
    private string prompt { get; set; }
    //testfil
    private TestFileDTO test { get; set; }

    public TranslationService(IRepoManager repoManager, IOpenAIService openAiIntegration)
    {
        _repoManager = repoManager;
        _lazyOpenAIIntegration = new Lazy<IOpenAIIntegration>(() => new OpenAIIntegration(openAiIntegration));
    }

    public IOpenAIIntegration OpenAIIntegration => _lazyOpenAIIntegration.Value;

    public async Task<string> translateTestfile(string prompt, TestFileDTO testFile)
    {
        var msg = prompt + testFile.Content;
        return await OpenAIIntegration.Request(msg);
    }



    //exceptionhandling
    //skal lægge documentation i DB
    //split output
}