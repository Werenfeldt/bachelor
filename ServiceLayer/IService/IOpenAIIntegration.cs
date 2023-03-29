namespace ServiceLayer;

public interface IOpenAIIntegration
{
    Task<string> Request(string s);
}
