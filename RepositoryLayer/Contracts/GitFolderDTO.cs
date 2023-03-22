namespace RepositoryLayer;

public record GitFolderDTO(Guid Id, string OwnerName, string Name, List<ScriptFileDTO> scriptFileDTOs);

public record CreateGitFolderDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public List<ScriptFileDTO> scriptFileDTOs {get; set;}

    // TODO add scriptfiles 
}

public record UpdateGitFolderDTO : CreateGitFolderDTO
{
    public string Name { get; set; }
    public string OwnerName { get; set; }
}
