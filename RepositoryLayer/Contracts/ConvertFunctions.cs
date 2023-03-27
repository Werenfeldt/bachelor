namespace RepositoryLayer;

public static class ConvertFunctions
{

    public static ProjectDTO ProjectMapToDTO(Project project)
    {
        return new ProjectDTO(project.Title, project.GitRepoName, project.GitRepoOwner, project.Description, project.CreatedDate.ToString(), GetUserDTOs(project), GetTestFileDTOs(project));
    }


    //TODO fix TestFile DTOs (sidste parameter) 
    public static ProjectDTO ProjectMapToDTO(CreateProjectDTO project)
    {
        return new ProjectDTO(project.Title, project.GitRepoName, project.GitRepoOwner, project.Description, project.CreatedDate.ToString(), project.Users.ToList().AsReadOnly(), GetTestFileDTOs(project).AsReadOnly());
    }

    public static Project ProjectMapToEntity(CreateProjectDTO project)
    {
        return new Project(project.Title, project.GitRepoName, project.GitRepoOwner, project.CreatedDate);
    }
    public static TestFileDTO TestFileMapToDTO(TestFile testFile)
    {
        return new TestFileDTO(testFile.Name, testFile.Path, testFile.Content, testFile.CreatedDate.ToString(), testFile.UpdatedDate.ToString(), ProjectMapToDTO(testFile.Project), DocumentationMapToDTO(testFile.Documentation));
    }

    public static TestFileDTO TestFileMapToDTO(CreateTestFileDTO testFile)
    {
        return new TestFileDTO(testFile.Name, testFile.Path, testFile.Content, testFile.CreatedDate.ToString(), null, testFile.Project, null);
    }

    public static TestFile TestFileMapToEntity(CreateTestFileDTO testFile)
    {
        return new TestFile(testFile.Name, testFile.Path, testFile.Content, testFile.CreatedDate);
    }
    private static DocumentationDTO DocumentationMapToDTO(Documentation documentation)
    {
        return new DocumentationDTO(documentation.Summary, documentation.Translation, documentation.CreatedDate.ToString(), documentation.UpdatedDate.ToString());
    }

    //TODO uncomment or delete


    // private static Documentation DocumentationMapToEntity(DocumentationDTO documentation)
    // {
    //     return new Documentation(documentation.Summary, documentation.Translation, DateTime.Parse(documentation.CreatedDate));
    // }


    private static UserDTO UserMapToDTO(User user)
    {
        return new UserDTO(user.Name, user.Email, user.CreatedDate.ToString());
    }

    private static UserDTO UserMapToDTO(UserDTO user)
    {
        return new UserDTO(user.Name, user.Email, user.CreatedDate.ToString());
    }

    private static List<TestFileDTO> GetTestFileDTOs(Project project)
    {
        var scriptList = new List<TestFileDTO>();

        if (project.TestFiles != null)
        {
            project.TestFiles.ToList().ForEach(testFile => scriptList.Add(TestFileMapToDTO(testFile)));
        }

        return scriptList;
    }

    private static List<TestFileDTO> GetTestFileDTOs(CreateProjectDTO project)
    {
        var scriptList = new List<TestFileDTO>();

        if (project.testFileToBeCreatedDTOs != null)
        {
            project.testFileToBeCreatedDTOs.ToList().ForEach(testFile => scriptList.Add(TestFileMapToDTO(testFile)));
        }

        return scriptList;
    }

    private static IReadOnlyCollection<UserDTO> GetUserDTOs(Project project)
    {
        var userList = new List<UserDTO>();

        if (project.Users != null)
        {
            project.Users.ToList().ForEach(user => userList.Add(UserMapToDTO(user)));
        }

        return userList.AsReadOnly();
    }

    //TODO uncomment or delete

    // private static IReadOnlyCollection<UserDTO> GetUserDTOs(CreateProjectDTO project)
    // {
    //     var userList = new List<UserDTO>();

    //     if (project.Users != null)
    //     {
    //         project.Users.ToList().ForEach(user => userList.Add(UserMapToDTO(user)));
    //     }

    //     return userList.AsReadOnly();
    // }




}