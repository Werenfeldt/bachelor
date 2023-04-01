namespace RepositoryLayer;

public record ProjectDTO(Guid Id, string title, string gitRepoName, string gitRepoOwner, string description, DateTime createdDate);

public record CreateProjectDTO
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string GitRepoName { get; set; }

    [Required]
    public string GitRepoOwner { get; set; }

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
