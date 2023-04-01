namespace RepositoryLayer;

public interface IUserRepository{
    Task<UserDTO> CreateUserAsync(CreateUserDTO user);
    Task<Option<UserDTO>> ReadUserByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<Option<UserDTO>> ReadUserByIdAsync(Guid id, CancellationToken cancellationToken = default);

    //Valgt ikke at have en "remove user" pga traceability.
}