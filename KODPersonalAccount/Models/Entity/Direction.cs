namespace KODPersonalAccount.Models.Entity;

public class Direction
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Group> Groups { get; set; }
}