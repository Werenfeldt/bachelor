namespace RepositoryLayer;

public interface ITestFileRepository
{
    Task<Option<TestFileDTO>> ReadTestFileByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TestFileDTO>> ReadAllTestFilesByProjectIdAsync(Guid projectId, CancellationToken cancellationToken = default);
}