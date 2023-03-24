using Microsoft.EntityFrameworkCore;

namespace DomainLayer;
public interface IBachelorDbContext : IDisposable
{
    DbSet<Project> Projects { get; }
    DbSet<TestFile> TestFiles { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}