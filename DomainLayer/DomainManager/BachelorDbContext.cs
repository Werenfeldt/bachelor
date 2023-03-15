using Microsoft.EntityFrameworkCore;

namespace DomainLayer;

public sealed class BachelorDbContext : DbContext
{
    public BachelorDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<ScriptFile> ScriptFiles { get; set; }

    public DbSet<GitFolder> GitFolder { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BachelorDbContext).Assembly);
}