namespace DomainLayer;

public class Documentation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }

    public string Summary { get; set; }

    public string Translation { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DataType(DataType.Date)]
    public DateTime UpdatedDate { get; set; }

    //Dependent entity therefore has id to principal entity
    public Guid TestFileId { get; set; }

    [Required]
    public TestFile? TestFile { get; set; }
    public Documentation(string summary, string translation)
    {
        Summary = summary;
        Translation = translation;
    }
}