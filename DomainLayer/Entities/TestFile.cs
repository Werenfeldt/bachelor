namespace DomainLayer;
public class TestFile
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Path { get; set; }
    public string Content { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedDate { get; set; }

    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? UpdatedDate { get; set; }

    //Dependent entity therefore has id to principal entity
    public Guid ProjectId { get; set; }
    
    public Project Project { get; set; } = null!;

    //Principal entity to documentation
    public Documentation? Documentation { get; set; }

    public TestFile(string name, string path, string content)
    {
        Name = name;
        Path = path;
        Content = content;
    }
}