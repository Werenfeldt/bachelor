namespace ServiceLayer;

public interface IOpenAIIntegration
{
    Task<(string,string)> Request(string s);
}
