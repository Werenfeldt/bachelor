namespace DomainLayer.Configurations;

internal sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(s => s.CreatedDate)
            .HasDefaultValueSql("date('now')");

        builder.Property(s => s.UpdatedDate)
            .HasDefaultValueSql("date('now')");

        var guid3 = Guid.NewGuid();
        var guid4 = Guid.NewGuid();
        var guid5 = Guid.NewGuid();


        builder.HasData(
            new Project("Project 1", "Repo1")
            {
                Id = Guid.Parse("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                Description = "Dette er en beskrivelse",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new Project("Project 2", "Repo2")
            {
                Id = Guid.Parse("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                Description = "Dette er en beskrivelse",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new Project("Project 3", "Repo3")
            {
                Id = guid3,
                Description = "Dette er en beskrivelse",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new Project("Project 4", "Repo4")
            {
                Id = guid4,
                Description = "Dette er en beskrivelse",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new Project("Project 5", "Repo5")
            {
                Id = guid5,
                Description = "Dette er en beskrivelse",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
        );

        builder.HasMany(p => p.Users).WithMany(u => u.Projects).UsingEntity(pu => pu.ToTable("UsersProject").HasData(
            new
            {
                ProjectsId = Guid.Parse("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                UsersId = Guid.Parse("596bd00e-8699-4183-850f-14dc879bf9d8")
            },
            new
            {
                ProjectsId = Guid.Parse("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                UsersId = Guid.Parse("5f6bd9e2-569f-40ea-8f27-79f3b87e1638")
            },
            new
            {
                ProjectsId = Guid.Parse("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                UsersId = Guid.Parse("596bd00e-8699-4183-850f-14dc879bf9d8")
            },
            new
            {
                ProjectsId = Guid.Parse("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                UsersId = Guid.Parse("5f6bd9e2-569f-40ea-8f27-79f3b87e1638")
            },
            new
            {
                ProjectsId = guid3,
                UsersId = Guid.Parse("596bd00e-8699-4183-850f-14dc879bf9d8")
            },
            new
            {
                ProjectsId = guid4,
                UsersId = Guid.Parse("596bd00e-8699-4183-850f-14dc879bf9d8")
            },
            new
            {
                ProjectsId = guid5,
                UsersId = Guid.Parse("596bd00e-8699-4183-850f-14dc879bf9d8")
            }
        ));

    }
}
