namespace RepositoryLayer;

public record ProjectDTO(Guid Id, string title, string gitUrl, string description, DateTime createdDate);

public record ProjectWithTestFilesDTO(Guid Id, string Title, IEnumerable<TestFileDTO> testfiles);

public record CreateProjectDTO
{
    [Required(ErrorMessage = "A project title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "A GitHub URL is required.")]
    public string GitUrl { get; set; }

    public string Description { get; set; }

    [Required]
    //The user who creates the project
    public Guid UserId { get; set; }

    public ICollection<CreateTestFileDTO> TestFileToBeCreatedDTOs { get; set; }

}

public record UpdateProjectDTO : CreateProjectDTO
{
    public Guid Id { get; set; }

    public ICollection<Guid> UserIds { get; set; }

    //If project testfiles are updated, TestFilesToBeCREATED has to be null. 
    public ICollection<UpdateTestFileDTO> TestFileToBeUpdatedDTOs { get; set; }
}
