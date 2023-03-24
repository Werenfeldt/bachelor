namespace DomainLayer;

public class Documentation
{
    [Key]
    public Guid Id { get; set; }

    public string Summary { get; set; }

    public string Translation { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? UpdatedDate { get; set; }

    public Guid TestFileId { get; set; }

    [Required]
    public TestFile? TestFile { get; set; }
    public Documentation(string summary, string translation, DateTime createdDate)
    {
        Summary = summary;
        Translation = translation;
        createdDate = CreatedDate;
    }
}