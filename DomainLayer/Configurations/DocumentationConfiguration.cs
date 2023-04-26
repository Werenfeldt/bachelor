namespace DomainLayer.Configurations;

internal sealed class DocumentationConfiguration : IEntityTypeConfiguration<Documentation>
{
    public void Configure(EntityTypeBuilder<Documentation> builder)
    {
        builder.Property(s => s.CreatedDate)
            .HasDefaultValueSql("date('now')");

        builder.Property(s => s.UpdatedDate)
            .HasDefaultValueSql("date('now')");

        builder.HasOne(d => d.TestFile).WithOne(t => t.Documentation).HasForeignKey<Documentation>(d => d.TestFileId);

        builder.HasData(
            new Documentation("Jeg er et summary", "Jeg er en translation")
            {
                Id = Guid.NewGuid(),
                TestFileId = Guid.Parse("6ea2fe17-3be2-4990-aa44-d233698ac483"),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
        );
    }
}