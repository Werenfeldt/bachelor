using Domain.Repositories;
using Services.Interfaces;

namespace Services.Service;

internal sealed class ScriptService : IScriptService
{
    private readonly IRepoManager _repoManager;
    public ScriptService(IRepoManager repoManager) => _repoManager = repoManager;
    
    public Task<ScriptDto> CreateAsync(Guid ownerId, CreateScriptDto scriptForCreationDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ScriptDto>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ScriptDto> GetByIdAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}