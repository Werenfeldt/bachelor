namespace RepositoryLayer;

internal sealed class UserRepository : IUserRepository
{
    private readonly BachelorDbContext _dbContext;

    public UserRepository(BachelorDbContext dbContext) => _dbContext = dbContext;

    public async Task<Option<UserDTO>> ReadUserByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password==password);

        return user != null ? ConvertFunctions.UserMapToDTO(user) : null;
    }
    
    public async Task<UserDTO> CreateUserAsync(CreateUserDTO user)
    {
        var _user = ConvertFunctions.UserMapToEntity(user);
        await _dbContext.AddAsync(_user);
        await _dbContext.SaveChangesAsync();
        return ConvertFunctions.UserMapToDTO(_user);
    }
}