namespace RepositoryLayer;

public interface IScriptFileRepository
{
    Task<IEnumerable<ScriptFile>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
    Task<ScriptFile> GetByIdAsync(Guid scriptId, CancellationToken cancellationToken = default);
    Task<ScriptFileDTO> Insert(CreateScriptFileDTO script);
    void Remove(ScriptFile script);
}