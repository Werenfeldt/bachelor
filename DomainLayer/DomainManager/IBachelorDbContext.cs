namespace DomainLayer;
public interface IBachelorDbContext : IDisposable
{
    DbSet<User> Users { get; }
    DbSet<TestFile> TestFiles { get; }
    DbSet<Project> Projects { get; }
    DbSet<Documentation> Documentation { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}