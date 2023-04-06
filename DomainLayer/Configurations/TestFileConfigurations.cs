namespace DomainLayer.Configurations;

internal sealed class TestFileConfiguration : IEntityTypeConfiguration<TestFile>
{
    public void Configure(EntityTypeBuilder<TestFile> builder)
    {
        builder.Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(s => s.UpdatedDate)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(t => t.Project).WithMany(p => p.TestFiles).HasForeignKey(t => t.ProjectId);
        
        builder.HasOne(t => t.Documentation).WithOne(d => d.TestFile).HasForeignKey<Documentation>(d => d.TestFileId);
        
        builder.HasData(
            new TestFile("TestFile 1", "somePath", "Jeg er et script content")
            {
                Id = Guid.Parse("ee61a729-a960-467a-bdc1-1d7184ee7346"),
                ProjectId = Guid.Parse("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new TestFile("TestFile 2", "somePath2", "Jeg er også et script")
            {
                Id = Guid.Parse("6ea2fe17-3be2-4990-aa44-d233698ac483"),
                ProjectId = Guid.Parse("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new TestFile("TestFile 3", "somePath3", "Jeg er også et script")
            {
                Id = Guid.Parse("21444a04-eea6-4d61-84b6-2d260463a923"),
                ProjectId = Guid.Parse("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new TestFile("TestFile 4", "somePath4", "Jeg er også et script")
            {
                Id = Guid.NewGuid(),
                ProjectId = Guid.Parse("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new TestFile("TestFile 5", "somePath5", "Jeg er også et script")
            {
                Id = Guid.NewGuid(),
                ProjectId = Guid.Parse("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new TestFile("TestFile 6", "somePath6", "Jeg er også et script")
            {
                Id = Guid.NewGuid(),
                ProjectId = Guid.Parse("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
        );
    }
}
