namespace DomainLayer.Configurations;

internal sealed class DocumentationConfiguration : IEntityTypeConfiguration<Documentation>
{
    public void Configure(EntityTypeBuilder<Documentation> builder)
    {
        builder.Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(s => s.UpdatedDate)
            .HasDefaultValueSql("GETDATE()");
    }
}