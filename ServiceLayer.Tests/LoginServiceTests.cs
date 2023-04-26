namespace ServiceLayer.Tests;


public class LoginServiceTests : ContextSetup
{
    [Fact]
    public async Task Login_given_email_and_password_returns_userDTO()
    {
        var user = await _serviceManager.LoginService.Login("Jens@gmail.com", "1234");

        Assert.Equal("Jens@gmail.com", user.Email);
        Assert.Equal("Jens", user.Name);
    }

    [Fact]
    public async Task Login_given_wrong_email_and_password_returns_exception()
    {
        await Assert.ThrowsAsync<UserNotFoundException>(async () => await _serviceManager.LoginService.Login("wrong", "wrong"));
    }

    [Fact]
    public async Task createNewUser_given_createUserDTO_returns_UserDTO()
    {
        var createUserDTO = new CreateUserDTO()
        {
            Name = "Alice",
            Email = "Bond@gmail.com",
            Password = "Bond123"
        };

        var created = await _serviceManager.LoginService.CreateNewUser(createUserDTO);

        Assert.Equal(createUserDTO.Name, created.Name);
        Assert.Equal(createUserDTO.Email, created.Email);
    }
}