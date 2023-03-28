namespace ServiceLayer;

public class LoginService : ILoginService
{
    private readonly IRepoManager _repoManager;

    public LoginService(IRepoManager repoManager) => _repoManager = repoManager;
    public async Task<UserDTO> Login(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _repoManager.UserRepository.GetByNameAndPassword(email, password, cancellationToken);

        if (user != null)
        {
            return ConvertFunctions.UserMapToDTO(user);
        }

        throw new UserNotFoundException("User does not exist. Please check password and email. Otherwise create new use");
    }

    public async Task<UserDTO> CreateNewUser(CreateUserDTO user)
    {
        user.CreatedDate = DateTime.UtcNow;

        return await _repoManager.UserRepository.Insert(user);
    }

}