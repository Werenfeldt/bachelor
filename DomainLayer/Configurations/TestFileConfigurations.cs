using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations;

internal sealed class TestFileConfiguration : IEntityTypeConfiguration<TestFile>
{
    public void Configure(EntityTypeBuilder<TestFile> builder)
    {
        //TODO Reintroduce
        //builder.Property(script => script.OwnerId).IsRequired();

        builder.Property(script => script.Name).HasMaxLength(60);

        builder.HasOne(script => script.Project).WithMany(gitfolder => gitfolder.TestFiles);
    }
}
