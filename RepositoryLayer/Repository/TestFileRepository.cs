namespace RepositoryLayer;

internal sealed class TestFileRepository : ITestFileRepository
{
    private readonly BachelorDbContext _dbContext;

    public TestFileRepository(BachelorDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<TestFileDTO>> ReadAllTestFilesByProjectIdAsync(Guid projectId, CancellationToken cancellationToken = default) => 
        await _dbContext.TestFiles.Where(tf => tf.ProjectId == projectId).Select(tf => ConvertFunctions.TestFileMapToDTO(tf)).ToListAsync();
       

    public async Task<Option<TestFileDTO>> ReadTestFileByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.TestFiles.FindAsync(Id);

        return entity != null ? ConvertFunctions.TestFileMapToDTO(entity) : null;
    }
}
