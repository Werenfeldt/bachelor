namespace RepositoryLayer;

public record DocumentationDTO(string Summary, string Translation, string CreatedDate, string UpdatedDate);

public record CreateDocumentationDTO
{
    public string? Summary { get; set; }

    public string? Translation { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
    
    public TestFileDTO? TestFile { get; set; }
}

public record UpdateDocumentationDTO : CreateDocumentationDTO
{
    public Guid Id { get; set; }

    [DataType(DataType.Date)]
    public DateTime? UpdatedDate { get; set; }
}