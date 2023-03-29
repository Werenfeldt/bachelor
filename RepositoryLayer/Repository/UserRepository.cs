namespace RepositoryLayer;

public class UserRepository : IUserRepository
{
    private readonly BachelorDbContext _dbContext;

    public UserRepository(BachelorDbContext dbContext) => _dbContext = dbContext;
    public async Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
        await _dbContext.Users.FindAsync(userId, cancellationToken);

    public async Task<User> GetByNameAndPassword(string email, string password, CancellationToken cancellationToken = default) =>
        await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password==password);
    

    public async Task<UserDTO> Insert(CreateUserDTO user)
    {
        var _user = ConvertFunctions.UserMapToEntity(user);
        await _dbContext.AddAsync(_user);
        await _dbContext.SaveChangesAsync();
        return ConvertFunctions.UserMapToDTO(user);
    }
}