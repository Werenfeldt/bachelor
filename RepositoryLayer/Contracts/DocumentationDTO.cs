namespace RepositoryLayer;

public record DocumentationDTO(Guid Id, string Summary, string Translation, Guid TestFileId, DateTime CreatedDate, DateTime UpdatedDate);

public record CreateDocumentationDTO
{
    [Required]
    public string Summary { get; set; }

    [Required]
    public string Translation { get; set; }
    
    [Required]
    public Guid TestFileId { get; set; }
}

public record UpdateDocumentationDTO : CreateDocumentationDTO
{
    public Guid Id { get; set; }
}