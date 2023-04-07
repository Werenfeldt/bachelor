

namespace DomainLayer;
[Index(nameof(GitUrl), IsUnique = true)]
//TODO set up deletion cascade. 
public class Project
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string GitUrl { get; set; }

    public string? Description { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedDate { get; set; }

    [Required]
    public ICollection<User>? Users { get; set; }

    //Principal entity to TestFiles
    public ICollection<TestFile>? TestFiles { get; set; }

    public Project(string title, string gitUrl)
    {
        Title = title;
        GitUrl = gitUrl;
        Users = new List<User>();
    }
}