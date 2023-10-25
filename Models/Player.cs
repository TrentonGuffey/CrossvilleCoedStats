using System.Collections.Generic;
namespace CrossvilleCoed.Models;

public class Player
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PositionId { get; set; }
    public Position? Pos { get; set; }
    public int TeamId { get; set; }
    public List<PlayerGame>? PlayerGames { get; set; }
    public Team? Team { get; set; }
    public double OfficialAtBats
    {
        get
        {
            if (PlayerGames == null)
            {
                return 0;
            }
            double atBats = 0;
            foreach (PlayerGame playerGame in PlayerGames)
            {
                atBats += playerGame.TotalPlateAppearances - playerGame.Walk - playerGame.Sacrifice;
            }
            return atBats;
        }
    }
    public double TotalHits
    {
        get
        {
            if (PlayerGames == null)
            {
                return 0;
            }
            double tHits = 0;
            foreach (PlayerGame playerGame in PlayerGames)
            {
                tHits += playerGame.Single + playerGame.Double + playerGame.Triple + playerGame.HomeRun;
            }
            return tHits;
        }
    }
    public decimal BattingAverage
    {
        get
        {
            if (OfficialAtBats == 0)
            {
                return 0;
            }

            decimal batAverage = (decimal)TotalHits / (decimal)OfficialAtBats;

            return Math.Round(batAverage, 3);
        }
    }
    public double RunsProduced
    {
        get
        {
            if (PlayerGames == null)
            {
                return 0;
            }
            double runsProduced = 0;
            foreach (PlayerGame playerGame in PlayerGames)
            {
                runsProduced += playerGame.RunsBattedIn + playerGame.RunsScored;
            }
            return runsProduced;
        }
    }
    public double TotalRBIs
    {
        get
        {
            if (PlayerGames == null)
            {
                return 0;
            }
            double rBIS = 0;
            foreach (PlayerGame playerGame in PlayerGames)
            {
                rBIS += playerGame.RunsBattedIn;
            }
            return rBIS;
        }
    }  
    public double TotalRunsScored
    {
        get
        {
            if (PlayerGames == null)
            {
                return 0;
            }
            double runScord = 0;
            foreach (PlayerGame playerGame in PlayerGames)
            {
                runScord += playerGame.RunsScored;
            }
            return runScord;
        }
    }     
}

