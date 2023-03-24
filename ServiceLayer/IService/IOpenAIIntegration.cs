namespace ServiceLayer;

public interface IOpenAIIntegration
{
    Task<IEnumerable<TestFileDTO>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

    Task<TestFileDTO> GetByIdAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken);

    Task<TestFileDTO> CreateAsync(Guid ownerId, CreateTestFileDTO scriptForCreationDto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid ownerId, Guid scriptId, CancellationToken cancellationToken = default);

    Task<string> Translate(string s);

}
