namespace RepositoryLayer;

internal sealed class TestFileRepository : ITestFileRepository
{
    private readonly BachelorDbContext _dbContext;

    public TestFileRepository(BachelorDbContext dbContext) => _dbContext = dbContext;

    //TODO reintroduce
    // public async Task<IEnumerable<TestFile>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
    //     await _dbContext.TestFiles.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);

    public async Task<TestFile> GetByIdAsync(Guid scriptId, CancellationToken cancellationToken = default) =>
        await _dbContext.TestFiles.FirstOrDefaultAsync(x => x.Id == scriptId, cancellationToken);

    public async Task<TestFileDTO> Insert(CreateTestFileDTO script)
    {
        var result = script.Adapt<TestFile>();

        await _dbContext.TestFiles.AddAsync(result);
        
        return new TestFileDTO(script.Id, script.DateCreated, script.Name, script.GitUrl, script.HtmlUrl, script.Url, script.Path, script.Sha, script.Content);
    } 

    public void Remove(TestFile script) => _dbContext.TestFiles.Remove(script);
}
