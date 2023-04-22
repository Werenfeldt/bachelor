namespace ServiceLayer.Tests;

public class ProjectRepositoryTests : ContextSetup
{
    [Fact]
    public async Task CreateProject_given_CreateProjectDTO_and_authtoken_returns_ProjectDTO()
    {
        var createProjectDTO = new CreateProjectDTO()
        {
            Title = "Test",
            GitUrl = "https://github.com/JeppeKorgaard98/bachelortest",
            Description = "I am a description",
            UserId = new Guid("596bd00e-8699-4183-850f-14dc879bf9d8"),
            TestFileToBeCreatedDTOs = new List<CreateTestFileDTO>()
        };
        string tokenAuth = "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";
        var created = await _serviceManager.ProjectService.CreateProjectAsync(createProjectDTO, tokenAuth);

        Console.WriteLine(created.ToString());

        Assert.Equal(createProjectDTO.Title, created.title);
        Assert.Equal(createProjectDTO.GitUrl, created.gitUrl);
        Assert.Equal(createProjectDTO.Description, created.description);
        Assert.Equal(DateTime.UtcNow, created.createdDate, precision: TimeSpan.FromSeconds(5));


    }

    [Fact]
    public async Task CreateProject_given_CreateProjectDTO_and_username_password_returns_projectDTO()
    {
        var createProjectDTO = new CreateProjectDTO()
        {
            Title = "Test",
            GitUrl = "https://github.com/JeppeKorgaard98/bachelortest",
            Description = "I am a description",
            UserId = new Guid("596bd00e-8699-4183-850f-14dc879bf9d8"),
            TestFileToBeCreatedDTOs = new List<CreateTestFileDTO>()
        };
        string username = "Jens";
        string password = "Jens123";
        var created = await _serviceManager.ProjectService.CreateProjectAsync(createProjectDTO, username, password);

        Console.WriteLine(created.ToString());

        Assert.Equal(createProjectDTO.Title, created.title);
        Assert.Equal(createProjectDTO.GitUrl, created.gitUrl);
        Assert.Equal(createProjectDTO.Description, created.description);
        Assert.Equal(DateTime.UtcNow, created.createdDate, precision: TimeSpan.FromSeconds(5));
    }

    [Fact]
    public async Task LoadProjects_given_userId_returns_projectDTO_list()
    {

    }

}