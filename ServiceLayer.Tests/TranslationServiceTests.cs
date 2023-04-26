namespace ServiceLayer.Tests;

public class TranslationServiceTests : ContextSetup
{
    [Fact]
    public async Task TranslateTestFile_given_testfileDTO_returns_DocumentationDTO()
    {
        var user = await CreateTestUser();
        var project = await CreateTestProject1(user.Id);
        var testfiles = await _serviceManager.ProjectService.LoadTestFilesForProjectAsync(project.Id);

        var documentation = await _serviceManager.TranslationService.TranslateTestfile(testfiles[0]);

        Assert.True(!String.IsNullOrEmpty(documentation.Summary));
        Assert.True(!String.IsNullOrEmpty(documentation.Translation));
    }

    [Fact]
    public async Task UpdateDocumentation_given_UpdateDocumentationDTO_returns_response()
    {
        var user = await CreateTestUser();
        var project = await CreateTestProject1(user.Id);
        var testfiles = await _serviceManager.ProjectService.LoadTestFilesForProjectAsync(project.Id);

        var documentation = await _serviceManager.TranslationService.TranslateTestfile(testfiles[0]);

        var response = await _serviceManager.TranslationService.UpdateDocumentation(new UpdateDocumentationDTO()
        {
            Id = documentation.Id,
            Summary = "Test Summary",
            Translation = "Test Translation",
            TestFileId = testfiles[0].Id
        });

        var updated = await _serviceManager.ProjectService.LoadDocumentationByTestFilesIdAsync(testfiles[0].Id);

        Assert.Equal(Response.Updated, response);
        Assert.Equal("Test Summary", updated.Summary);
        Assert.Equal("Test Translation", updated.Translation);
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

}