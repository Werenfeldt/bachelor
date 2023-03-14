namespace RepositoryLayer;

public interface IScriptRepository
{
    Task<IEnumerable<Script>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
    Task<Script> GetByIdAsync(Guid scriptId, CancellationToken cancellationToken = default);
    void Insert(Script script);
    void Remove(Script script);
}