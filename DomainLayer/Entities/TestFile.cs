using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer;
public class TestFile
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Path { get; set; }
    public string Content { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? UpdatedDate { get; set; }

    public Guid ProjectId { get; set; }
    
    [Required]
    public Project? Project { get; set; }

    

    public TestFile(string name, string path, string content, DateTime createdDate )
    {
        Name = name;
        Path = path;
        Content = content;
        CreatedDate = createdDate;

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