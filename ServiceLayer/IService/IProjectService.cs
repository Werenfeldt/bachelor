namespace ServiceLayer;

public interface IProjectService
{
    Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO projectDTO);

    Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO projectDTO, string tokenAuth);

    Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO projectDTO, string username, string password);

    Task<List<ProjectDTO>> LoadProjectsAsync(Guid userId);
}