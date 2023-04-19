namespace DomainLayer.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");
        
        builder.HasData(
            new User("Jens", "Jens@gmail.com", "1234")
            {
                Id = Guid.Parse("596bd00e-8699-4183-850f-14dc879bf9d8"),
                CreatedDate = DateTime.UtcNow,
            },
            new User("Bo", "Bo@gmail.com", "1234")
            {
                Id = Guid.Parse("5f6bd9e2-569f-40ea-8f27-79f3b87e1638"),
                CreatedDate = DateTime.UtcNow,
            }
        );
    }
}