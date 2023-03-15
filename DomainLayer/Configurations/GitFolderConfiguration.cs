using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations;

internal sealed class GitFolderConfiguration : IEntityTypeConfiguration<ScriptFile>
{
    public void Configure(EntityTypeBuilder<ScriptFile> builder)
    {
        builder.Property(gitFolder => gitFolder.OwnerId).IsRequired();

        builder.Property(gitFolder => gitFolder.Name).HasMaxLength(60);
    }
}
