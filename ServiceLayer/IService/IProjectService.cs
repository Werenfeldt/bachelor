namespace ServiceLayer;

public interface IProjectService
{
    Task<ProjectDTO> CreateProjectAsync(string url);

    Task<ProjectDTO> CreateProjectAsync(string url, string tokenAuth);

    Task<ProjectDTO> CreateProjectAsync(string url, string username, string password);
}