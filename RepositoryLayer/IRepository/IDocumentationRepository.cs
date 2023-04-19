namespace RepositoryLayer;

public interface IDocumentationRepository{
    Task<DocumentationDTO> CreateDocumentationAsync(CreateDocumentationDTO documentation);
    Task<Option<DocumentationDTO>> ReadDocumentationByTestFileIdAsync(Guid testFileId, CancellationToken cancellationToken = default);
    Task<Response> UpdateDocumentationAsync(UpdateDocumentationDTO documentationDTO);
}