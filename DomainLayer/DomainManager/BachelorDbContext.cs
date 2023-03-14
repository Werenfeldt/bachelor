using Microsoft.EntityFrameworkCore;

namespace DomainLayer;

public sealed class BachelorDbContext : DbContext
{
    public BachelorDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Script> Scripts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BachelorDbContext).Assembly);
}