namespace RepositoryLayer;

public record TestFileDTO(Guid Id, string Name, string Path, string Content, Guid ProjectId, DateTime CreatedDate, DateTime? UpdatedDate);

public record TestFileWithDocumentationDTO(Guid Id, string Name, DocumentationDTO Documentation);

public record CreateTestFileDTO
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Path { get; set; }

    public string Content { get; set; }
}

public record UpdateTestFileDTO : CreateTestFileDTO
{
    public Guid Id { get; set; }
}


