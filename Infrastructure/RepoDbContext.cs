using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public sealed class RepoDbContext : DbContext
{
    public RepoDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Script> Scripts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepoDbContext).Assembly);
}