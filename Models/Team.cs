namespace CrossvilleCoed.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}