namespace DomainLayer.Configurations;

internal sealed class TestFileConfiguration : IEntityTypeConfiguration<TestFile>
{
    public void Configure(EntityTypeBuilder<TestFile> builder)
    {
        builder.Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(s => s.UpdatedDate)
            .HasDefaultValueSql("GETDATE()");
    }
}
