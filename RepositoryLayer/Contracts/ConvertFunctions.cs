namespace RepositoryLayer;

public static class ConvertFunctions
{

    public static ProjectDTO ProjectMapToDTO(Project project)
    {
        var scriptList = new List<TestFileDTO>();

        foreach (var script in project.TestFiles)
        {
            scriptList.Add(TestFileMapToDTO(script));
        }

        return new ProjectDTO(project.Id, project.OwnerName, project.Name, scriptList);
    }

    public static ProjectDTO ProjectMapToDTO(CreateProjectDTO project)
    {
        return new ProjectDTO(project.Id, project.OwnerName, project.Name, project.testFileDTOs);
    }

    public static Project ProjectMapToEntity(CreateProjectDTO project)
    {
        var scriptList = new List<TestFile>();

        foreach (var script in project.testFileDTOs)
        {
            scriptList.Add(TestFileMapToEntity(script));
        }

        return new Project(project.Name, project.OwnerName) { TestFiles = scriptList };

    }

    private static TestFile TestFileMapToEntity(TestFileDTO testFile)
    {
        return new TestFile(testFile.GitUrl, testFile.HtmlUrl, testFile.Url, testFile.Path, testFile.Name, testFile.Sha, testFile.Content);
    }

    private static TestFileDTO TestFileMapToDTO(TestFile testFile)
    {
        return new TestFileDTO(testFile.Id, testFile.DateCreated, testFile.Name, testFile.GitUrl, testFile.HtmlUrl, testFile.ApiUrl, testFile.FilePath, testFile.Sha, testFile.RawContent);
    }


}