namespace CrossvilleCoed.Models;

public class PlayerGame
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public Player? Player { get; set; }
    public int GameId { get; set; }
    public Game? Game { get; set; }
    public double TotalPlateAppearances { get; set; }
    public int Single { get; set; }
    public int Double { get; set; }
    public int Triple { get; set; }
    public int HomeRun { get; set; }
    public int Walk { get; set; }
    public int Sacrifice { get; set; }
    public int FieldersChoice { get; set; }
    public int RunsBattedIn { get; set; }
    public int RunsScored { get; set; }

}