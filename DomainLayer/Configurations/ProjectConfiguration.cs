namespace DomainLayer.Configurations;

internal sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(s => s.UpdatedDate)
            .HasDefaultValueSql("GETDATE()");
    }
}
