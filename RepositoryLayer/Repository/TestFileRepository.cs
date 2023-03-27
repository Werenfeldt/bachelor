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

    public async Task<TestFileDTO> Insert(CreateTestFileDTO testFile)
    {
        var result = ConvertFunctions.TestFileMapToEntity(testFile);

        await _dbContext.TestFiles.AddAsync(result);

        await _dbContext.SaveChangesAsync();

        //TODO change so we dont convert twice maybe?. 
        return ConvertFunctions.TestFileMapToDTO(testFile);
    } 

    public void Remove(TestFile script) => _dbContext.TestFiles.Remove(script);
}
