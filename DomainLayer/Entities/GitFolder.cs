using System.ComponentModel.DataAnnotations;

namespace DomainLayer;

public class GitFolder
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    // TODO introduce this again
    //public Guid OwnerId { get; set; }

    public string OwnerName { get; set; }
    public List<ScriptFile>? ScriptFiles { get; set; }

    public GitFolder(string name, string ownerName)
    {
        Name = name;
        OwnerName = ownerName;
    }
}