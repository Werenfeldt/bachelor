
namespace ServiceLayer;

public record ScriptDto(Guid Id, Guid OwnerId, DateTime DateCreated, string FileName, string Translation, string Github);

public record CreateScriptDto
{
    public Guid Id { get; set; }

    public Guid OwnerId { get; set; }

    public DateTime DateCreated { get; set; }

    public string FileName { get; set; }

    public string Translation { get; set; }

    public string Github { get; set; }
}

public record UpdateScriptDto : CreateScriptDto
{
    public Guid Id { get; set; }

    public string FileName { get; set; }

    public string Translation { get; set; }

}


