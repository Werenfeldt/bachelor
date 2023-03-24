using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer;
public class TestFile
{
    [Key]
    public Guid Id { get; set; }

    //TODO Reintroduce
    //public Guid OwnerId { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; }

    public string? Translation { get; set; }

    public string GitUrl { get; set; }
    public string HtmlUrl { get; set; }
    public string ApiUrl { get; set; }
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string Sha { get; set; }
    public string RawContent { get; set; }

    public Guid ProjectId { get; set; }
    
    [ForeignKey("ProjectId")]
    public Project? Project { get; set; }

    public TestFile(string gitUrl, string htmlUrl, string apiUrl, string filePath, string name, string sha, string rawContent)
    {
        GitUrl = gitUrl;
        HtmlUrl = htmlUrl;
        ApiUrl = apiUrl;
        FilePath = filePath;
        Name = name;
        Sha = sha;
        RawContent = rawContent;
    }

    public override string ToString()
    {
        return "File Name: " + Name + "\n"
                + "File Path: " + FilePath + "\n"
                + "Raw Content:" + "\n"
                + "============================" + "\n"
                + RawContent + "\n"
                + "============================" + "\n";
    }

}