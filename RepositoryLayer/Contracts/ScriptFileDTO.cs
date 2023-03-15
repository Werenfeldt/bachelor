namespace RepositoryLayer;

public record ScriptFileDTO(Guid Id, DateTime DateCreated, string Name, string GitUrl, string HtmlUrl, string Url, string Path, string Sha, string Content);

public record CreateScriptFileDTO
{
    public Guid Id { get; set; }

    //public Guid OwnerId { get; set; }

    public DateTime DateCreated { get; set; }

    public string Name { get; set; }

    public string GitUrl { get; set; }

    public string HtmlUrl { get; set; }

    public string Url { get; set; }

    public string Path { get; set; }

    public string Sha { get; set; }

    public string Content { get; set; }

}

public record UpdateScriptFileDTO : CreateScriptFileDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Url { get; set; }

}


