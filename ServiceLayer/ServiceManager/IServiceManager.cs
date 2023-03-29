namespace ServiceLayer;

public interface IServiceManager
{
    IOpenAIIntegration OpenAIIntegration { get; }

    ILoginService LoginService { get; }
}