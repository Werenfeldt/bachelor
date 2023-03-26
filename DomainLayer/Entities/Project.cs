

namespace DomainLayer;
//TODO set up deletion cascade. 
public class Project
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string GitRepoName { get; set; }

    public string GitRepoOwner { get; set; }

    public string? Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [Required]
    public ICollection<User>? Users { get; set; }

    //Principal entity to TestFiles
    public ICollection<TestFile>? TestFiles { get; set; }

    public Project(string title, string gitRepoName, string gitRepoOwner, DateTime createdDate)
    {
        Title = title;
        GitRepoName = gitRepoName;
        GitRepoOwner = gitRepoOwner;
        CreatedDate = createdDate;
    }
}