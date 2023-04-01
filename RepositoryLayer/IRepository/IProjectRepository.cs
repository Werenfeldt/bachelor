namespace RepositoryLayer;

public interface IProjectRepository{
    Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO project);
    Task<Option<ProjectDTO>> ReadProjectByIdAsync(Guid projectId, CancellationToken cancellationToken = default);

    Task<IEnumerable<ProjectDTO>> ReadAllProjectsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<Response> UpdateProjectAsync(UpdateProjectDTO project);
    Task<Response> DeleteProjectAsync(Guid projectId);
}