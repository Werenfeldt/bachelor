namespace Domain.Entities;
public class Script
{
    public Guid Id { get; set; }

    public Guid OwnerId { get; set; }

    public DateTime DateCreated { get; set; }

    public string FileName { get; set; }

    public string Translation { get; set; }

    public string Github { get; set; }


}