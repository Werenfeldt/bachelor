namespace RepositoryLayer;

internal sealed class ProjectRepository : IProjectRepository
{
    private readonly BachelorDbContext _dbContext;

    public ProjectRepository(BachelorDbContext dbContext) => _dbContext = dbContext;

    public async Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO projectDTO)
    {
        var entity = await _dbContext.Projects.Where(p => p.GitUrl == projectDTO.GitUrl).FirstOrDefaultAsync();
        if (entity == null)
        {
            var project = ConvertFunctions.ProjectMapToEntity(projectDTO);

            //Adds logged in user to project entity        
            var user = await _dbContext.Users.FindAsync(projectDTO.UserId);
            project.Users.Add(user);

            //Adds project to database
            await _dbContext.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return ConvertFunctions.ProjectMapToDTO(project);
        }
        else
        {
            var user = await _dbContext.Users.FindAsync(projectDTO.UserId);
            entity.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return ConvertFunctions.ProjectMapToDTO(entity);
        }
    }

    public async Task<Option<ProjectDTO>> ReadProjectByIdAsync(Guid projectId, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Projects.FindAsync(projectId);

        return entity != null ? ConvertFunctions.ProjectMapToDTO(entity) : null;
    }

    public async Task<IEnumerable<ProjectDTO>> ReadAllProjectsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.Include(user => user.Projects).Where(user => user.Id == userId).FirstOrDefaultAsync();

        return user.Projects.Select(p => ConvertFunctions.ProjectMapToDTO(p));
    }

    public async Task<Response> UpdateProjectAsync(UpdateProjectDTO project)
    {
        var entity = await _dbContext.Projects.FindAsync(project.Id);

        if (entity != null)
        {
            var updatedEntity = ConvertFunctions.ProjectMapToEntity(project);
            _dbContext.Projects.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();

            return Response.Updated;
        }
        return Response.NotFound;
    }
    public async Task<Response> DeleteProjectAsync(Guid projectId)
    {
        //var entity = await _dbContext.Projects.Include(p => p.TestFiles).Include(p => p.TestFiles.Select(t => t.Documentation)).Where(p => p.Id == projectId).FirstOrDefaultAsync();

        var entity = await _dbContext.Projects.FindAsync(projectId);
        
        if (entity != null)
        {

            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return Response.Deleted;
        }
        return Response.NotFound;
    }
}