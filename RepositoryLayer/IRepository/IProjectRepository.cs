namespace RepositoryLayer;

public interface IProjectRepository
{
    Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO project);

    Task<IEnumerable<ProjectDTO>> ReadAllProjectsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<IEnumerable<ProjectWithTestFilesDTO>> ReadAllProjectsWithTestFilesByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<Response> UpdateProjectAsync(UpdateProjectDTO project);
    Task<Response> DeleteProjectAsync(Guid projectId);
}