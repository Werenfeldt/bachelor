using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class ScriptRepository : IScriptRepository
{
    private readonly RepoDbContext _dbContext;

    public ScriptRepository(RepoDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Script>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
        await _dbContext.Scripts.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);

    public async Task<Script> GetByIdAsync(Guid scriptId, CancellationToken cancellationToken = default) =>
        await _dbContext.Scripts.FirstOrDefaultAsync(x => x.Id == scriptId, cancellationToken);

    public void Insert(Script script) => _dbContext.Scripts.Add(script);

    public void Remove(Script script) => _dbContext.Scripts.Remove(script);
}
