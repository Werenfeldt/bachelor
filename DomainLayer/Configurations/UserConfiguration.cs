namespace DomainLayer.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");
    }
}