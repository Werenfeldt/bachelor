namespace RepositoryLayer;

public record UserDTO(string Name, string Email, string CreatedDate);

public record CreateUserDTO
{
    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
}

public record UpdateUserDTO : CreateProjectDTO
{
    public Guid Id { get; set; }

    public ICollection<ProjectDTO>? Projects { get; set; }
}