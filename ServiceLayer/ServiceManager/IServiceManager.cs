namespace ServiceLayer;

public interface IServiceManager
{
    ILoginService LoginService { get; }

    IProjectService ProjectService { get; }
}