namespace ServiceLayer;

public class LoginService : ILoginService
{
    private readonly IRepoManager _repoManager;

    public LoginService(IRepoManager repoManager) => _repoManager = repoManager;
    public async Task<UserDTO> Login(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _repoManager.UserRepository.ReadUserByEmailAndPasswordAsync(email, password, cancellationToken);

        if (user.IsSome)
        {
            return user.Value;
        }

        throw new UserNotFoundException("User does not exist. Please check password and email. Otherwise create new use");
    }

    public async Task<UserDTO> CreateNewUser(CreateUserDTO user)
    {
        return await _repoManager.UserRepository.CreateUserAsync(user);
    }

}