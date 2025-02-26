namespace KODPersonalAccount.Models.Entity;

public class UserToGroup
{
    public long UserId { get; set; }
    public long GroupId { get; set; }

    public User User { get; set; }
    public Group Group { get; set; }
}