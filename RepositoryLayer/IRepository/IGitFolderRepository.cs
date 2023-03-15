namespace RepositoryLayer;

public interface IGitFolderRepository{
    Task<IEnumerable<GitFolder>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
    Task<GitFolder> GetByIdAsync(Guid gitFolderId, CancellationToken cancellationToken = default);
    Task<GitFolderDTO> Insert(CreateGitFolderDTO gitFolder);
    void Remove(GitFolder gitFolder);
}