namespace ServiceLayer;

public interface IProjectService
{
    Task<ProjectDTO> CreateProjectAsync(Guid userId, string projectTitle, string projectDescription, string url);

    Task<ProjectDTO> CreateProjectAsync(Guid userId, string projectTitle, string projectDescription, string url, string tokenAuth);

    Task<ProjectDTO> CreateProjectAsync(Guid userId, string projectTitle, string projectDescription, string url, string username, string password);

    Task<List<ProjectDTO>> LoadProjectsAsync(Guid userId);
}