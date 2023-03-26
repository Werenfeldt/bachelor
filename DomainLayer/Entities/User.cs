namespace DomainLayer;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public string? Email { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    public ICollection<Project>? Projects { get; set; }

    public User(string name, string password, DateTime createdDate)
    {
        Name = name;
        Password = password;
        CreatedDate = createdDate;
    }

}