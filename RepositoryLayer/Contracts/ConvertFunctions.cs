namespace RepositoryLayer;

public static class ConvertFunctions
{

    // -------------------------------------- Project mappings ------------------------------------------//
    public static ProjectDTO ProjectMapToDTO(Project project)
    {
        return new ProjectDTO(project.Id, project.Title, project.GitUrl, project.Description, project.CreatedDate);
    }

    public static ProjectWithTestFilesDTO ProjectWithTestFilesMapToDTO(Project project)
    {
        var testFiles = new List<TestFileDTO>();

        foreach (var testFile in project.TestFiles)
        {
            testFiles.Add(TestFileMapToDTO(testFile));
        }
        return new ProjectWithTestFilesDTO(project.Id, project.Title, testFiles);
    }

    public static Project ProjectMapToEntity(CreateProjectDTO project)
    {
        return new Project(project.Title, project.GitUrl)
        {
            Description = project.Description,
            TestFiles = GetTestFiles(project.TestFileToBeCreatedDTOs)
        };
    }

    public static Project ProjectMapToEntity(UpdateProjectDTO project)
    {
        return new Project(project.Title, project.GitUrl)
        {
            Description = project.Description,
            TestFiles = GetTestFiles(project.TestFileToBeUpdatedDTOs)
        };
    }

    //-------------------------------------- TestFile mappings ------------------------------------------//
    public static TestFileDTO TestFileMapToDTO(TestFile testFile)
    {
        return new TestFileDTO(testFile.Id, testFile.Name, testFile.Path, testFile.Content, testFile.ProjectId, testFile.CreatedDate, testFile.UpdatedDate);
    }

    public static TestFile TestFileMapToEntity(CreateTestFileDTO testFile)
    {
        return new TestFile(testFile.Name, testFile.Path, testFile.Content);
    }

    public static TestFile TestFileMapToEntity(UpdateTestFileDTO testFile)
    {
        return new TestFile(testFile.Name, testFile.Path, testFile.Content) { Id = testFile.Id };
    }


    //-------------------------------------- User mappings ------------------------------------------//
    public static UserDTO UserMapToDTO(User user)
    {
        return new UserDTO(user.Id, user.Name, user.Email, user.CreatedDate);
    }

    public static User UserMapToEntity(CreateUserDTO user)
    {
        return new User(user.Name, user.Email, user.Password);
    }


    //-------------------------------------- Documentation mappings ------------------------------------------//
    public static DocumentationDTO DocumentationMapToDTO(Documentation documentation)
    {
        return new DocumentationDTO(documentation.Id, documentation.Summary, documentation.Translation, documentation.TestFileId, documentation.CreatedDate, documentation.UpdatedDate);
    }

    public static Documentation DocumentationMapToDTO(CreateDocumentationDTO documentation)
    {
        return new Documentation(documentation.Summary, documentation.Translation) { TestFileId = documentation.TestFileId };
    }

    //-------------------------------------- Util ------------------------------------------//
    private static List<TestFile> GetTestFiles(ICollection<CreateTestFileDTO> testFileDTOs)
    {
        List<TestFile> testFiles = new List<TestFile>();

        if (testFileDTOs != null)
        {
            foreach (var item in testFileDTOs)
            {
                testFiles.Add(TestFileMapToEntity(item));
            }
        }

        return testFiles;
    }

    private static List<TestFile> GetTestFiles(ICollection<UpdateTestFileDTO> testFileDTOs)
    {
        List<TestFile> testFiles = new List<TestFile>();

        if (testFileDTOs != null)
        {
            foreach (var item in testFileDTOs)
            {
                testFiles.Add(TestFileMapToEntity(item));
            }
        }

        return testFiles;
    }
}