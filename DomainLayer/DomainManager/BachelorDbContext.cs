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

    public DbSet<TestFile> TestFiles => Set<TestFile>();

    public DbSet<Project> Projects => Set<Project>();
}