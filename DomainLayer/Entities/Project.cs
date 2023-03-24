namespace DomainLayer;

public class Project
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string GitRepoName { get; set; }

    public string GitRepoOwner { get; set; }

    public string? Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    //public string User { get; set; }
    public ICollection<TestFile>? TestFiles { get; set; }

    public Project(string title, string gitRepoName, string gitRepoOwner, DateTime createdDate)
    {
        Title = title;
        GitRepoName = gitRepoName;
        GitRepoOwner = gitRepoOwner;
        CreatedDate = createdDate;
    }
}