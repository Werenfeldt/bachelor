using Microsoft.EntityFrameworkCore;

namespace DomainLayer;

public sealed class BachelorDbContext : DbContext, IBachelorDbContext
{
    public BachelorDbContext(DbContextOptions<BachelorDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(BachelorDbContext).Assembly);

    public DbSet<ScriptFile> ScriptFiles => Set<ScriptFile>();

    public DbSet<GitFolder> GitFolders => Set<GitFolder>();
}