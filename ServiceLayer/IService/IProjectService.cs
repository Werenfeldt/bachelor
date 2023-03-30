namespace ServiceLayer;

public interface IProjectService
{
    Task<ProjectDTO> CreateProjectAsync(UserDTO user, string url);

    Task<ProjectDTO> CreateProjectAsync(UserDTO user, string url, string tokenAuth);

    Task<ProjectDTO> CreateProjectAsync(UserDTO user, string url, string username, string password);
}