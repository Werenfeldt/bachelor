namespace RepositoryLayer;

public interface IRepoManager
{
    ITestFileRepository TestFileRepository { get; }

    IProjectRepository ProjectRepository { get; }

    IUserRepository UserRepository { get; }

    IDocumentationRepository DocumentationRepository { get; }

}
