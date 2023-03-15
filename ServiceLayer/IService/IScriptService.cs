namespace ServiceLayer;

public interface IScriptService
{
    Task<IEnumerable<ScriptFileDTO>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

    Task<ScriptFileDTO> GetByIdAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken);

    Task<ScriptFileDTO> CreateAsync(Guid ownerId, CreateScriptFileDTO scriptForCreationDto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken = default);

    Task<string> Translate(string s);

}
