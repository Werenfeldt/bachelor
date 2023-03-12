using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
//using Contracts;
namespace Services.Interfaces;

public interface IScriptService
{
    Task<IEnumerable<ScriptDto>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

    Task<ScriptDto> GetByIdAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken);

    Task<ScriptDto> CreateAsync(Guid ownerId, CreateScriptDto scriptForCreationDto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken = default);

}
