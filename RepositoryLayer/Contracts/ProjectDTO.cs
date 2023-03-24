namespace RepositoryLayer;

public record ProjectDTO(Guid Id, string OwnerName, string Name, List<TestFileDTO> testFileDTOs);

public record CreateProjectDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public List<TestFileDTO> testFileDTOs {get; set;}

    // TODO add scriptfiles 
}

public record UpdateProjectDTO : CreateProjectDTO
{
    public string Name { get; set; }
    public string OwnerName { get; set; }
}
