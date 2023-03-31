namespace RepositoryLayer;

public record UserDTO(Guid Id, string Name, string Email, DateTime CreatedDate);

public record CreateUserDTO
{
    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "Password must be at least 4 characters long.", MinimumLength = 4)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }


}