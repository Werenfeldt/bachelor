using System.ComponentModel.DataAnnotations;

namespace DomainLayer;

public class Project
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    // TODO introduce this again
    //public Guid OwnerId { get; set; }

    public string OwnerName { get; set; }
    public List<TestFile>? TestFiles { get; set; }

    public Project(string name, string ownerName)
    {
        Name = name;
        OwnerName = ownerName;
    }
}