namespace RepositoryLayer;

public interface IProjectRepository{
    //TODO introduce this again
    //Task<IEnumerable<Project>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
    Task<Project> GetByIdAsync(Guid projectId, CancellationToken cancellationToken = default);
    Task<ProjectDTO> Insert(CreateProjectDTO project);
    void Remove(Project project);
}