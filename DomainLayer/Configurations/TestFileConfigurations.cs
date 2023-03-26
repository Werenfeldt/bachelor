using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations;

internal sealed class TestFileConfiguration : IEntityTypeConfiguration<TestFile>
{
    public void Configure(EntityTypeBuilder<TestFile> builder)
    {
    }
}
