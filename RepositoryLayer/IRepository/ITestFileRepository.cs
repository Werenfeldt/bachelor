namespace RepositoryLayer;

public interface ITestFileRepository
{
    //TODO reintroduce
    //Task<IEnumerable<TestFile>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
    Task<TestFile> GetByIdAsync(Guid scriptId, CancellationToken cancellationToken = default);
    Task<TestFileDTO> Insert(CreateTestFileDTO script);
    void Remove(TestFile script);
}