namespace ServiceLayer.Tests;

public class TranslationServiceTests : ContextSetup
{
    [Fact]
    public async Task TranslateTestFile_given_testfileDTO_returns_DocumentationDTO()
    {

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