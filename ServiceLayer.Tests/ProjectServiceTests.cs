namespace ServiceLayer.Tests;

public class ProjectRepositoryTests : ContextSetup
{
    [Fact]
    public async Task CreateProject_given_CreateProjectDTO_and_authtoken_returns_ProjectDTO()
    {
        var user = await CreateTestUser();
        var project = await CreateTestProject1(user.Id);

        Assert.Equal("Test1", project.title);
        Assert.Equal("https://github.com/JeppeKorgaard98/bachelortest", project.gitUrl);
        Assert.Equal("I am a description", project.description);
        Assert.Equal(DateTime.UtcNow, project.createdDate, precision: TimeSpan.FromSeconds(5));
    }

    [Fact]
    public async Task CreateProject_given_CreateProjectDTO_and__wrong_authtoken_returns_exception()
    {
        var user = await CreateTestUser();
        var createProjectDTO = new CreateProjectDTO()
        {
            Title = "Test1",
            GitUrl = "https://github.com/JeppeKorgaard98/bachelortest",
            Description = "I am a description",
            UserId = user.Id,
            TestFileToBeCreatedDTOs = new List<CreateTestFileDTO>()
        };

        await Assert.ThrowsAsync<Octokit.AuthorizationException>(async () => await _serviceManager.ProjectService.CreateProjectAsync(createProjectDTO, "wrong key"));
    }

    [Fact]
    public async Task LoadProjects_given_userId_returns_list_of_ProjectDTO()
    {
        var user = await CreateTestUser();

        var project1 = await CreateTestProject1(user.Id);
        var project2 = await CreateTestProject2(user.Id);

        var resultList = await _serviceManager.ProjectService.LoadProjectsAsync(user.Id);

        Assert.Equal("Test1", resultList[0].title);
        Assert.Equal("https://github.com/JeppeKorgaard98/bachelortest", resultList[0].gitUrl);
        Assert.Equal("I am a description", resultList[0].description);
        Assert.Equal("Test2", resultList[1].title);
        Assert.Equal("https://github.com/cypress-io/cypress-realworld-app", resultList[1].gitUrl);
        Assert.Equal("I am a description", resultList[1].description);
        Assert.Equal(2, resultList.Count);
    }

    [Fact]
    public async Task LoadProjects_given_wrong_userId_throws_exception()
    {
        await Assert.ThrowsAsync<System.NullReferenceException>(async () => await _serviceManager.ProjectService.LoadProjectsAsync(Guid.Empty));
    }

    [Fact]
    public async Task LoadTestFileById_given_id_returns_TestFileDTO()
    {
        var testFile = await _serviceManager.ProjectService.LoadTestFileByIdAsync(new Guid("ee61a729-a960-467a-bdc1-1d7184ee7346"));

        Assert.Equal("TestFile 1", testFile.Name);
        Assert.Equal("somePath", testFile.Path);
        Assert.Equal("Jeg er et script content", testFile.Content);
    }

    [Fact]
    public async Task LoadTestFileById_given_wrong_id_throws_exception()
    {
        await Assert.ThrowsAsync<TestFileDoesNotExistException>(async () => await _serviceManager.ProjectService.LoadTestFileByIdAsync(Guid.Empty));
    }

    [Fact]
    public async Task LoadTestFilesForProject_given_id_returns_list_of_TestFileDTO()
    {
        var user = await CreateTestUser();
        var project = await CreateTestProject1(user.Id);

        var testFiles = await _serviceManager.ProjectService.LoadTestFilesForProjectAsync(project.Id);

        Assert.Equal(2, testFiles.Count);
    }

    [Fact]
    public async Task LoadTestFilesForProject_given_wrong_id_returns_empty_list()
    {
        Assert.Empty(await _serviceManager.ProjectService.LoadTestFilesForProjectAsync(Guid.Empty));
    }

    [Fact]
    public async Task LoadSideBar_given_user_id_returns_list_of_ProjectWithTestFilesDTO()
    {
        var user = await CreateTestUser();
        var project = await CreateTestProject1(user.Id);

        var projectWithTestFilesDTO = await _serviceManager.ProjectService.LoadSideBar(user.Id);

        Assert.Equal(project.Id, projectWithTestFilesDTO[0].Id);
        Assert.Equal(project.title, projectWithTestFilesDTO[0].Title);
        Assert.Equal(2, projectWithTestFilesDTO[0].testfiles.Count());
    }

    [Fact]
    public async Task LoadSideBar_given_wrong_id_throws_exception()
    {
        await Assert.ThrowsAsync<System.NullReferenceException>(async () => await _serviceManager.ProjectService.LoadSideBar(Guid.Empty));

    }

    [Fact]
    public async Task LoadDocumentationByTestFilesId_given_id_returns_DocumentationDTO()
    {
        var user = await CreateTestUser();
        var project = await CreateTestProject1(user.Id);
        var testfiles = await _serviceManager.ProjectService.LoadTestFilesForProjectAsync(project.Id);

        var documentationAddedToDB = await _serviceManager.TranslationService.TranslateTestfile(testfiles[0]);

        var result = await _serviceManager.ProjectService.LoadDocumentationByTestFilesIdAsync(testfiles[0].Id);

        Assert.Equal(documentationAddedToDB.Id, result.Id);
        Assert.Equal(documentationAddedToDB.Summary, result.Summary);
        Assert.Equal(documentationAddedToDB.Translation, result.Translation);

    }

    [Fact]
    public async Task LoadDocumentationByTestFilesId_given_wrong_id_returns_empty_DocumentationDTO()
    {
        var result = await _serviceManager.ProjectService.LoadDocumentationByTestFilesIdAsync(Guid.Empty);

        Assert.Equal(Guid.Empty, result.Id);
        Assert.Equal(Guid.Empty, result.TestFileId);
        Assert.Equal("", result.Summary);
        Assert.Equal("", result.Translation);
        Assert.Equal(DateTime.UtcNow, result.CreatedDate, precision: TimeSpan.FromSeconds(5));
        Assert.Equal(DateTime.UtcNow, result.UpdatedDate, precision: TimeSpan.FromSeconds(5));
    }

    [Fact]
    public async Task DeleteProject_given_id_returns_ResponsDeleted()
    {
        var user = await CreateTestUser();
        var project = await CreateTestProject1(user.Id);
        var response = await _serviceManager.ProjectService.DeleteProject(project.Id);

        Assert.Equal(Response.Deleted, response);
    }




    // UTIL

    private async Task<UserDTO> CreateTestUser()
    {
        var createUserDTO = new CreateUserDTO()
        {
            Name = "Alice",
            Email = "Alice@gmail.com",
            Password = "Alice123"
        };
        return await _serviceManager.LoginService.CreateNewUser(createUserDTO);
    }

    private async Task<ProjectDTO> CreateTestProject1(Guid userId)
    {
        var createProjectDTO = new CreateProjectDTO()
        {
            Title = "Test1",
            GitUrl = "https://github.com/JeppeKorgaard98/bachelortest",
            Description = "I am a description",
            UserId = userId,
            TestFileToBeCreatedDTOs = new List<CreateTestFileDTO>()
        };
        return await _serviceManager.ProjectService.CreateProjectAsync(createProjectDTO, _testRepoGitKey);
    }

    private async Task<ProjectDTO> CreateTestProject2(Guid userId)
    {
        var createProjectDTO = new CreateProjectDTO()
        {
            Title = "Test2",
            GitUrl = "https://github.com/cypress-io/cypress-realworld-app",
            Description = "I am a description",
            UserId = userId,
            TestFileToBeCreatedDTOs = new List<CreateTestFileDTO>()
        };
        return await _serviceManager.ProjectService.CreateProjectAsync(createProjectDTO, _testRepoGitKey);
    }
}