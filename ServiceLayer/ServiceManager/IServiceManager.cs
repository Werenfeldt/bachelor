namespace ServiceLayer;

public interface IServiceManager
{
    IScriptService ScriptService { get; }

    IGithubService GithubService { get; }
}