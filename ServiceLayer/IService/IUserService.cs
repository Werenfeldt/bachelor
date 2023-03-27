namespace ServiceLayer;

public interface IUserService
{
    Task<UserDTO> Login(string email, string password, CancellationToken cancellationToken = default);
    Task<UserDTO> CreateNewUser(CreateUserDTO user);
}