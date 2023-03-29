namespace ServiceLayer;

public interface IServiceManager
{
    IOpenAIIntegration OpenAIIntegration { get; }

    IGithubIntegration GithubIntegration { get; }

    ILoginService LoginService { get; }
}