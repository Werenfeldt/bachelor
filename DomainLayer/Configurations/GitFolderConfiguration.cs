using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations;

internal sealed class ProjectConfiguration : IEntityTypeConfiguration<TestFile>
{
    public void Configure(EntityTypeBuilder<TestFile> builder)
    {
        //TODO Reintroduce
        //builder.Property(project => project.OwnerId).IsRequired();

        //builder.Property(project => project.Name).HasMaxLength(60);
    }
}
