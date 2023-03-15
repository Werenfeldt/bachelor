namespace RepositoryLayer;

internal sealed class ScriptFileRepository : IScriptFileRepository
{
    private readonly BachelorDbContext _dbContext;

    public ScriptFileRepository(BachelorDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<ScriptFile>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
        await _dbContext.ScriptFiles.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);

    public async Task<ScriptFile> GetByIdAsync(Guid scriptId, CancellationToken cancellationToken = default) =>
        await _dbContext.ScriptFiles.FirstOrDefaultAsync(x => x.Id == scriptId, cancellationToken);

    public async Task<ScriptFileDTO> Insert(CreateScriptFileDTO script)
    {
        var result = script.Adapt<ScriptFile>();

        await _dbContext.ScriptFiles.AddAsync(result);
        
        return new ScriptFileDTO(script.Id, script.DateCreated, script.Name, script.GitUrl, script.HtmlUrl, script.Url, script.Path, script.Sha, script.Content);
    } 

    public void Remove(ScriptFile script) => _dbContext.ScriptFiles.Remove(script);
}
