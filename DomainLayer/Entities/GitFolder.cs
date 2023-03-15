namespace DomainLayer;

public class GitFolder
{

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public List<ScriptFile> ScriptFiles { get; set; }
}