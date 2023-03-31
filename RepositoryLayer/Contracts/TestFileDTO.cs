namespace RepositoryLayer;

//TODO add simple record if you dont need all information

public record TestFileDTO(string Name, string Path, string Content, string CreatedDate, string UpdatedDate, DocumentationDTO Documentation);

public record CreateTestFileDTO
{
    public string? Name { get; set; }

    public string? Path { get; set; }
    public string? Content { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

}

public record UpdateTestFileDTO : CreateTestFileDTO
{
    public Guid Id { get; set; }

    [DataType(DataType.Date)]
    public DateTime? UpdatedDate { get; set; }

    public DocumentationDTO? Documentation { get; set; }

}


