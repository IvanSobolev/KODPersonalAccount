namespace KODPersonalAccount.Models.Entity;

public class User
{
    public long Id { get; set; }
    public string Role { get; set; }
    public string TgUsername { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public float Points { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiresToken { get; set; }
    
    public ICollection<Guid> GroupsIds { get; set; } = new List<Guid>();
    public ICollection<Guid> TaughtGroupsId { get; set; } = new List<Guid>();
    public ICollection<Guid> AttendedLessonIds { get; set; } = new List<Guid>();
}