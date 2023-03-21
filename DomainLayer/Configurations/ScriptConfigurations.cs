using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations;

internal sealed class ScriptConfiguration : IEntityTypeConfiguration<ScriptFile>
{
    public void Configure(EntityTypeBuilder<ScriptFile> builder)
    {
        //TODO Reintroduce
        //builder.Property(script => script.OwnerId).IsRequired();

        builder.Property(script => script.Name).HasMaxLength(60);

        builder.HasOne(script => script.Gitfolder).WithMany(gitfolder => gitfolder.ScriptFiles);
    }
}
