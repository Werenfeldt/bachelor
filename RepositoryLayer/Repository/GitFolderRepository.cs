namespace RepositoryLayer;

internal sealed class GitFolderRepository : IGitFolderRepository
{
    private readonly BachelorDbContext _dbContext;

    public GitFolderRepository(BachelorDbContext dbContext) => _dbContext = dbContext;
    public async Task<IEnumerable<GitFolder>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
        await _dbContext.GitFolder.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);

    public async Task<GitFolder> GetByIdAsync(Guid gitFolderId, CancellationToken cancellationToken = default) => 
        await _dbContext.GitFolder.FindAsync(gitFolderId, cancellationToken);

    public async Task<GitFolderDTO> Insert(CreateGitFolderDTO gitFolder){
        var result = gitFolder.Adapt<GitFolder>();

        await _dbContext.GitFolder.AddAsync(result);
        
        return gitFolder.Adapt<GitFolderDTO>();
    }

    public void Remove(GitFolder gitFolder) => _dbContext.GitFolder.Remove(gitFolder);
}