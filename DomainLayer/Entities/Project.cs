

namespace DomainLayer;
[Index(nameof(GitRepoName), nameof(GitRepoOwner), IsUnique = true)]
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

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedDate { get; set; }

    [Required]
    public ICollection<User>? Users { get; set; }

    //Principal entity to TestFiles
    public ICollection<TestFile>? TestFiles { get; set; }

    public Project(string title, string gitRepoName, string gitRepoOwner)
    {
        Title = title;
        GitRepoName = gitRepoName;
        GitRepoOwner = gitRepoOwner;
        Users = new List<User>();
    }
}