namespace ServiceLayer;

public interface IProjectService
{
    Task<ProjectDTO> CreateProjectAsync(Guid userId, string url);

    Task<ProjectDTO> CreateProjectAsync(Guid userId, string url, string tokenAuth);

    Task<ProjectDTO> CreateProjectAsync(Guid userId, string url, string username, string password);
}