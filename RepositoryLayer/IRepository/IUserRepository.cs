namespace RepositoryLayer;

public interface IUserRepository{
    Task<UserDTO> CreateUserAsync(CreateUserDTO user);
    Task<Option<UserDTO>> ReadUserByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken = default);
}