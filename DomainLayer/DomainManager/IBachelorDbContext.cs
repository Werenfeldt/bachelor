namespace DomainLayer;
public interface IBachelorDbContext : IDisposable
{
    DbSet<Project> Projects { get; }
    DbSet<TestFile> TestFiles { get; }
    DbSet<User> Users { get; }
    DbSet<Documentation> Documentation { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}