namespace RepositoryLayer;

internal sealed class GitFolderRepository : IGitFolderRepository
{
    private readonly BachelorDbContext _dbContext;

    public GitFolderRepository(BachelorDbContext dbContext) => _dbContext = dbContext;

    //TODO introduce this again
    // public async Task<IEnumerable<GitFolder>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
    //     await _dbContext.GitFolder.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);

    public async Task<GitFolder> GetByIdAsync(Guid gitFolderId, CancellationToken cancellationToken = default) =>
        await _dbContext.GitFolders.FindAsync(gitFolderId, cancellationToken);

    public async Task<GitFolderDTO> Insert(CreateGitFolderDTO gitFolder)
    {
        var result = ConvertFunctions.GitFolderMapToEntity(gitFolder);
        _dbContext.GitFolders.Add(result);
        await _dbContext.SaveChangesAsync();
        return ConvertFunctions.GitFolderMapToDTO(gitFolder);
    }

    public void Remove(GitFolder gitFolder) => _dbContext.GitFolders.Remove(gitFolder);
}