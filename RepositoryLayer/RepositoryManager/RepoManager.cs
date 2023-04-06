namespace RepositoryLayer;

public sealed class RepoManager : IRepoManager
{
    private readonly Lazy<ITestFileRepository> _lazyTestFileRepository;

    private readonly Lazy<IProjectRepository> _lazyProjectRepository;

    private readonly Lazy<IUserRepository> _lazyUserRepository;

    private readonly Lazy<IDocumentationRepository> _lazyDocumentationRepository;

    public RepoManager(BachelorDbContext dbContext)
    {
        _lazyTestFileRepository = new Lazy<ITestFileRepository>(() => new TestFileRepository(dbContext));
        _lazyProjectRepository = new Lazy<IProjectRepository>(() => new ProjectRepository(dbContext));
        _lazyUserRepository = new Lazy<IUserRepository>(()=> new UserRepository(dbContext));
        _lazyDocumentationRepository = new Lazy<IDocumentationRepository>(()=> new DocumentationRepository(dbContext));

    }

    public ITestFileRepository TestFileRepository => _lazyTestFileRepository.Value;

    public IProjectRepository ProjectRepository => _lazyProjectRepository.Value;

    public IUserRepository UserRepository => _lazyUserRepository.Value;

    public IDocumentationRepository DocumentationRepository => _lazyDocumentationRepository.Value;
}