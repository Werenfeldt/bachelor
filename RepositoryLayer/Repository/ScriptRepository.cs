using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer;

internal sealed class ScriptRepository : IScriptRepository
{
    private readonly BachelorDbContext _dbContext;

    public ScriptRepository(BachelorDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Script>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
        await _dbContext.Scripts.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);

    public async Task<Script> GetByIdAsync(Guid scriptId, CancellationToken cancellationToken = default) =>
        await _dbContext.Scripts.FirstOrDefaultAsync(x => x.Id == scriptId, cancellationToken);

    public void Insert(Script script) => _dbContext.Scripts.Add(script);

    public void Remove(Script script) => _dbContext.Scripts.Remove(script);
}
