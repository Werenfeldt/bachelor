namespace RepositoryLayer;

internal sealed class DocumentationRepository : IDocumentationRepository
{
    private readonly BachelorDbContext _dbContext;

    public DocumentationRepository(BachelorDbContext dbContext) => _dbContext = dbContext;
    public async Task<DocumentationDTO> CreateDocumentationAsync(CreateDocumentationDTO documentation)
    {
        var entity = ConvertFunctions.DocumentationMapToDTO(documentation);

        _dbContext.Documentation.Add(entity);
        await _dbContext.SaveChangesAsync();
        return ConvertFunctions.DocumentationMapToDTO(entity);
    }

    public async Task<IEnumerable<DocumentationDTO>> ReadAllDocumentationByProjectIdAsync(Guid projectId, CancellationToken cancellationToken = default)
    {
        //return await _dbContext.Documentation.Where(doc => doc.ProjectId == projectId).Select(doc => ConvertFunctions.DocumentationMapToDTO(doc)).ToListAsync();

        //if below works then remove the one above + projectid from documentation entity   
        return await _dbContext.TestFiles.Where(tf => tf.ProjectId == projectId).Select(tf => ConvertFunctions.DocumentationMapToDTO(tf.Documentation)).ToListAsync();
    }

    public async Task<Option<DocumentationDTO>> ReadDocumentationByTestFileIdAsync(Guid testFileId, CancellationToken cancellationToken = default)
    {
        var docu = await _dbContext.Documentation.Where(doc => doc.TestFileId == testFileId).FirstOrDefaultAsync();
        
        if(docu != null)
        {
            return ConvertFunctions.DocumentationMapToDTO(docu);
        }
        return null;
    }

    public async Task<Response> UpdateDocumentationAsync(UpdateDocumentationDTO documentationDTO)
    {
        var entity = await _dbContext.Documentation.FindAsync(documentationDTO.Id);

        if (entity != null)
        {
            var updatedEntity = ConvertFunctions.DocumentationMapToDTO(documentationDTO);
            _dbContext.Documentation.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();

            return Response.Updated;
        }
        return Response.NotFound;
    }
}
