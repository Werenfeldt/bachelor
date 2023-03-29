namespace RepositoryLayer;

public record UserDTO(string Name, string Email, string CreatedDate);

public record CreateUserDTO
{
    [Required]
    public string? Name { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
    public string? Password { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
}

public record UpdateUserDTO : CreateProjectDTO
{
    public Guid Id { get; set; }

    public ICollection<ProjectDTO>? Projects { get; set; }
}