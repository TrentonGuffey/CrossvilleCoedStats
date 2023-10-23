namespace CrossvilleCoed.Models;

public class Game
{
    public int Id { get; set; }
    public int HomeTeamId { get; set; }
    public Team? HomeTeam { get; set; }
    public int VisitorTeamId { get; set; }
    public Team? VisitorTeam { get; set; }
    public DateTime GameTime { get; set; }

}