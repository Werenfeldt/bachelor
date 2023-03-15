using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations;

internal sealed class ScriptConfiguration : IEntityTypeConfiguration<ScriptFile>
{
    public void Configure(EntityTypeBuilder<ScriptFile> builder)
    {
        builder.Property(script => script.OwnerId).IsRequired();

        builder.Property(script => script.Name).HasMaxLength(60);
    }
}
