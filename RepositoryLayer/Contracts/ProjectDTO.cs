

namespace RepositoryLayer;

public record ProjectDTO(string title, string gitRepoName, string gitRepoOwner, string description, string createdDate, IReadOnlyCollection<UserDTO> users, IReadOnlyCollection<TestFileDTO> testFileDTOs);

public record CreateProjectDTO
{
    public string? Title { get; set; }

    public string? GitRepoName { get; set; }

    public string? GitRepoOwner { get; set; }

    public string? Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    public UserDTO? User { get; set; }

    public ICollection<CreateTestFileDTO>? TestFileToBeCreatedDTOs { get; set; }
}

public record UpdateProjectDTO : CreateProjectDTO
{
    public Guid Id { get; set; }
}
