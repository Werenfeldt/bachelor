namespace ServiceLayer;

public interface IProjectService
{
    Task<ProjectDTO> CreateProjectAsync(Guid userId, string url);

    Task<ProjectDTO> CreateProjectAsync(Guid userId, string url, string tokenAuth);

    Task<ProjectDTO> CreateProjectAsync(Guid userId, string url, string username, string password);

    Task<List<ProjectDTO>> LoadProjectsAsync(Guid userId);

    Task<List<TestFileDTO>> LoadTestFilesForProjectAsync(Guid projectId);
}