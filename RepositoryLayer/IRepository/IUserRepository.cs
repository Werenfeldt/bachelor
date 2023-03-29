namespace RepositoryLayer;

public interface IUserRepository{
    Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<User> GetByNameAndPassword(string name, string password, CancellationToken cancellationToken = default);
    Task<UserDTO> Insert(CreateUserDTO user);

    //Valgt ikke at have en "remove user" pga traceability.
}