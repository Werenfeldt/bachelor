namespace RepositoryLayer;

internal sealed class ProjectRepository : IProjectRepository
{
    private readonly BachelorDbContext _dbContext;

    public ProjectRepository(BachelorDbContext dbContext) => _dbContext = dbContext;

    //TODO introduce this again
    // public async Task<IEnumerable<Project>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
    //     await _dbContext.Project.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);

    public async Task<Project> GetByIdAsync(Guid projectId, CancellationToken cancellationToken = default) =>
        await _dbContext.Projects.FindAsync(projectId, cancellationToken);

    public async Task<ProjectDTO> Insert(CreateProjectDTO projectDTO)
    {
        var project = ConvertFunctions.ProjectMapToEntity(projectDTO);
        var users = new List<User>();
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == projectDTO.User.Email);
        users.Add(user);
        project.Users = users;
        
        _dbContext.Projects.Add(project);
        await _dbContext.SaveChangesAsync();
        return ConvertFunctions.ProjectMapToDTO(project);
    }

    public void Remove(Project project) => _dbContext.Projects.Remove(project);
}