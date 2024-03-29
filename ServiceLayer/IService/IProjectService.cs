namespace ServiceLayer;

public interface IProjectService
{
    Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO projectDTO, string tokenAuth);
    Task<List<ProjectDTO>> LoadProjectsAsync(Guid userId);
    Task<TestFileDTO> LoadTestFileByIdAsync(Guid testFileId);
    Task<List<TestFileWithDocumentationDTO>> LoadTestFilesForProjectAsync(Guid projectId);
    Task<List<ProjectWithTestFilesDTO>> LoadSideBar(Guid userId);
    Task<DocumentationDTO> LoadDocumentationByTestFilesIdAsync(Guid testFileId);
    Task<Response> DeleteProject(Guid projectId);
}