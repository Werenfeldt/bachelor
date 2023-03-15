namespace RepositoryLayer;

public record GitFolderDTO(Guid Id, string Owner, string Name, List<ScriptFileDTO> scriptFileDTOs);

public record CreateGitFolderDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
    public List<ScriptFileDTO> scriptFileDTOs {get; set;}

    // TODO add scriptfiles 
}

public record UpdateGitFolderDTO : CreateGitFolderDTO
{
    public string Name { get; set; }
    public string Owner { get; set; }
}
