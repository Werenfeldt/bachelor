using Microsoft.EntityFrameworkCore;

namespace DomainLayer;
public interface IBachelorDbContext : IDisposable
{
    DbSet<GitFolder> GitFolders { get; }
    DbSet<ScriptFile> ScriptFiles { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}