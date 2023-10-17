using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CrossvilleCoed.Models;
using Microsoft.AspNetCore.Identity;

namespace CrossvilleCoed.Data;
public class CrossvilleCoedDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Game> Games  { get; set; }
    public DbSet<Player> Players  { get; set; }
    public DbSet<PlayerGame> PlayerGames  { get; set; }
    public DbSet<Position> Positions  { get; set; }
    public DbSet<Team> Teams  { get; set; }
    public DbSet<UserProfile> UserProfiles  { get; set; }
    public CrossvilleCoedDbContext(DbContextOptions<CrossvilleCoedDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[]
        {
            new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "admin"
            },
            new IdentityRole
            {
                Id = "1d373bd0-c738-40ee-bff1-b135b40a7be9",
                Name = "Coach",
                NormalizedName = "coach"
            }
        });
        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Administrator",
                Email = "tjguffey50@gmail.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "01ccfa71-2781-48bf-8e35-196e48859662",
                UserName = "FairOaksFarms",
                Email = "Camie.Miller@gmail.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["FairOaksFarmsPassword"])
            },        
            new IdentityUser
            {
                Id = "4eeea886-15a8-46d0-a26b-57ed40a5ee0a",
                UserName = "CampbellsPestControl",
                Email = "Wayne.Burns@gmail.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["CampbellsPestControlPassword"])
            }        
        });
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
        {
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", //Admin Role
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            },        
            new IdentityUserRole<string>
            {
                RoleId = "1d373bd0-c738-40ee-bff1-b135b40a7be9", //Coach Role
                UserId = "01ccfa71-2781-48bf-8e35-196e48859662"
            },        
            new IdentityUserRole<string>
            {
                RoleId = "1d373bd0-c738-40ee-bff1-b135b40a7be9",
                UserId = "4eeea886-15a8-46d0-a26b-57ed40a5ee0a"
            }        
            });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Trenton",
                LastName = "Guffey",
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "01ccfa71-2781-48bf-8e35-196e48859662",
                FirstName = "Camie",
                LastName = "Miller",
            },
            new UserProfile
            {
                Id = 3,
                IdentityUserId = "4eeea886-15a8-46d0-a26b-57ed40a5ee0a",
                FirstName = "Wayne",
                LastName = "Burns",
            }
        });
        modelBuilder.Entity<Team>().HasData(new Team[]
        {
            new Team
            {
                Id = 1,
                Name = "Fair Oaks Farms",
                UserProfileId = 2
            },
            new Team
            {
                Id = 2,
                Name = "Campbells Pest Control",
                UserProfileId = 3
            },
        });
        modelBuilder.Entity<Position>().HasData(new Position[]
        {
            new Position
            {
                Id = 1,
                Pos = "P"
            },
            new Position
            {
                Id = 2,
                Pos = "C"
            },
            new Position
            {
                Id = 3,
                Pos = "1B"
            },
            new Position
            {
                Id = 4,
                Pos = "2B"
            },
            new Position
            {
                Id = 5,
                Pos = "3B"
            },
            new Position
            {
                Id = 6,
                Pos = "SS"
            },
            new Position
            {
                Id = 7,
                Pos = "OF"
            },
            new Position
            {
                Id = 8,
                Pos = "EH"
            },
        });
        modelBuilder.Entity<Player>().HasData(new Player[]
        {
            new Player
            {
                Id = 1,
                FirstName = "Trenton",
                LastName = "Guffey",
                TeamId = 1,
                PositionId = 1                
            },
            new Player
            {
                Id = 2,
                FirstName = "Ethan",
                LastName = "Todd",
                TeamId = 1,
                PositionId = 6                
            },
            new Player
            {
                Id = 3,
                FirstName = "Tyler",
                LastName = "Richardson",
                TeamId = 1,
                PositionId = 7                 
            },
            new Player
            {
                Id = 4,
                FirstName = "Camie",
                LastName = "Miller",
                TeamId = 1,
                PositionId = 7                 
            },
            new Player
            {
                Id = 5,
                FirstName = "John aka Paco",
                LastName = "Rolan",
                TeamId = 1,
                PositionId = 1                 
            },
            new Player
            {
                Id = 6,
                FirstName = "Jonathan",
                LastName = "Stout",
                TeamId = 1,
                PositionId = 5                 
            },
            new Player
            {
                Id = 7,
                FirstName = "Karli",
                LastName = "Threet",
                TeamId = 1,
                PositionId = 3                 
            },
            new Player
            {
                Id = 8,
                FirstName = "Riley",
                LastName = "Norris",
                TeamId = 1,
                PositionId = 7                
            },
            new Player
            {
                Id = 9,
                FirstName = "Scottie",
                LastName = "Payne",
                TeamId = 1,
                PositionId = 2                 
            },
            new Player
            {
                Id = 10,
                FirstName = "Tori",
                LastName = "Stout",
                TeamId = 1,
                PositionId = 4                 
            },
            new Player
            {
                Id = 11,
                FirstName = "Chandler",
                LastName = "Hardwick",
                TeamId = 1,
                PositionId = 7                 
            },
            new Player
            {
                Id = 12,
                FirstName = "Jade",
                LastName = "Payne",
                TeamId = 1,
                PositionId = 4                
            },
            new Player
            {
                Id = 13,
                FirstName = "Chance",
                LastName = "Clark",
                TeamId = 2,
                PositionId = 1                 
            },
            new Player
            {
                Id = 14,
                FirstName = "Wayne",
                LastName = "Burns",
                TeamId = 2,
                PositionId = 1                 
            },
            new Player
            {
                Id = 15,
                FirstName = "Justin",
                LastName = "Timmons",
                TeamId = 2,
                PositionId = 6                
            },
            new Player
            {
                Id = 16,
                FirstName = "Russell",
                LastName = "Campbell",
                TeamId = 2,
                PositionId = 7                
            },
            new Player
            {
                Id = 17,
                FirstName = "Dora",
                LastName = "Erazocordova",
                TeamId = 2,
                PositionId = 2                 
            },
            new Player
            {
                Id = 18,
                FirstName = "Destiny",
                LastName = "Ruppe",
                TeamId = 2,
                PositionId = 7                 
            },
            new Player
            {
                Id = 19,
                FirstName = "Brent",
                LastName = "Bowman",
                TeamId = 2,
                PositionId = 1                
            },
            new Player
            {
                Id = 20,
                FirstName = "Jessica",
                LastName = "Lancianese",
                TeamId = 2,
                PositionId = 3                
            },
            new Player
            {
                Id = 21,
                FirstName = "Kendall",
                LastName = "Cooper",
                TeamId = 2,
                PositionId = 7                
            },
            new Player
            {
                Id = 22,
                FirstName = "Nick",
                LastName = "Bowman",
                TeamId = 2,
                PositionId = 5                 
            },
            new Player
            {
                Id = 23,
                FirstName = "Chris",
                LastName = "Patton",
                TeamId = 2,
                PositionId = 5                
            },
            new Player
            {
                Id = 24,
                FirstName = "Christa",
                LastName = "Wendig",
                TeamId = 2,
                PositionId = 4                 
            },
            new Player
            {
                Id = 25,
                FirstName = "Joseph",
                LastName = "Haley",
                TeamId = 2,
                PositionId = 7                
            },
            new Player
            {
                Id = 26,
                FirstName = "Justin",
                LastName = "Carr",
                TeamId = 2,
                PositionId = 7                 
            },
            new Player
            {
                Id = 27,
                FirstName = "Tanner",
                LastName = "Hurd",
                TeamId = 2,
                PositionId = 7                
            },
        });
        modelBuilder.Entity<Game>().HasData(new Game[]
        {
            new Game
            {
                Id = 1,
                HomeTeamId = 1,
                VisitorTeamId = 2,
                GameTime = new DateTime(2023, 10, 02, 18, 15, 00)
            },
            new Game
            {
                Id = 2,
                HomeTeamId = 2,
                VisitorTeamId = 1,
                GameTime = new DateTime(2023, 10, 05, 19, 15, 00)
            },
            new Game
            {
                Id = 3,
                HomeTeamId = 1,
                VisitorTeamId = 2,
                GameTime = new DateTime(2023, 10, 09, 18, 15, 00)
            },
            new Game
            {
                Id = 4,
                HomeTeamId = 2,
                VisitorTeamId = 1,
                GameTime = new DateTime(2023, 10, 12, 19, 15, 00)
            },
        });
        modelBuilder.Entity<PlayerGame>().HasData(new PlayerGame[]
        {
            new PlayerGame
            {
                Id = 1,
                PlayerId = 15,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 2,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 4
            },
            new PlayerGame
            {
                Id = 2,
                PlayerId = 25,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 2,
                Triple = 0,
                HomeRun = 1,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 4
            },
            new PlayerGame
            {
                Id = 3,
                PlayerId = 22,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 1,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 4,
                PlayerId = 24,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 5,
                PlayerId = 23,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 1,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 6,
                PlayerId = 18,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 1,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 7,
                PlayerId = 19,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 1,
                Double = 2,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 8,
                PlayerId = 26,
                GameId = 1,
                TotalPlateAppearances = 3,
                Single = 1,
                Double = 1,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 1,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 9,
                PlayerId = 17,
                GameId = 1,
                TotalPlateAppearances = 3,
                Single = 1,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 1,
                RunsScored = 0
            },
            new PlayerGame
            {
                Id = 10,
                PlayerId = 14,
                GameId = 1,
                TotalPlateAppearances = 3,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 11,
                PlayerId = 3,
                GameId = 1,
                TotalPlateAppearances = 3,
                Single = 2,
                Double = 2,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 12,
                PlayerId = 7,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 1,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 1,
                Sacrifice = 0,
                FieldersChoice = 1,
                RunsBattedIn = 0,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 13,
                PlayerId = 2,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 0,
                Double = 0,
                Triple = 1,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 14,
                PlayerId = 8,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 0,
                Double = 2,
                Triple = 1,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 4,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 15,
                PlayerId = 10,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 1,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 16,
                PlayerId = 9,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 1,
                RunsBattedIn = 1,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 17,
                PlayerId = 1,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 3,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 1,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 18,
                PlayerId = 4,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 0,
                Double = 1,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 1,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 19,
                PlayerId = 5,
                GameId = 1,
                TotalPlateAppearances = 4,
                Single = 0,
                Double = 1,
                Triple = 0,
                HomeRun = 2,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 4,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 20,
                PlayerId = 11,
                GameId = 1,
                TotalPlateAppearances = 3,
                Single = 1,
                Double = 2,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 21,
                PlayerId =  6,
                GameId = 1,
                TotalPlateAppearances = 3,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 1,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 22,
                PlayerId =  15,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 2,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 23,
                PlayerId =  25,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 1,
                Double = 2,
                Triple = 0,
                HomeRun = 1,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 4
            },
            new PlayerGame
            {
                Id = 24,
                PlayerId =  22,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 2,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 4
            },
            new PlayerGame
            {
                Id = 25,
                PlayerId =  24,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 26,
                PlayerId =  23,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 1,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 27,
                PlayerId =  18,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 28,
                PlayerId =  19,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 29,
                PlayerId =  26,
                GameId = 2,
                TotalPlateAppearances = 3,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 30,
                PlayerId =  17,
                GameId = 2,
                TotalPlateAppearances = 3,
                Single = 1,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 1,
                RunsScored = 0
            },
            new PlayerGame
            {
                Id = 31,
                PlayerId =  14,
                GameId = 2,
                TotalPlateAppearances = 3,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 3,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 32,
                PlayerId =  3,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 2,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 33,
                PlayerId =  7,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 1,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                Walk = 3,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 0,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 34,
                PlayerId =  2,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 0,
                Double = 0,
                Triple = 1,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 1,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 35,
                PlayerId =  8,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 0,
                Double = 2,
                Triple = 1,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 4,
                RunsScored = 2
            },
            new PlayerGame
            {
                Id = 36,
                PlayerId = 10,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 2,
                Double = 1,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 37,
                PlayerId =  1,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 3,
                Double = 0,
                Triple = 0,
                HomeRun = 1,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 1,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 38,
                PlayerId =  4,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 0,
                Double = 1,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 1,
                RunsScored = 1
            },
            new PlayerGame
            {
                Id = 39,
                PlayerId =  5,
                GameId = 2,
                TotalPlateAppearances = 4,
                Single = 0,
                Double = 1,
                Triple = 0,
                HomeRun = 2,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 4,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 40,
                PlayerId =  11,
                GameId = 2,
                TotalPlateAppearances = 3,
                Single = 1,
                Double = 2,
                Triple = 0,
                HomeRun = 0,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 3
            },
            new PlayerGame
            {
                Id = 41,
                PlayerId =  6,
                GameId = 2,
                TotalPlateAppearances = 3,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 1,
                Walk = 0,
                Sacrifice = 0,
                FieldersChoice = 0,
                RunsBattedIn = 2,
                RunsScored = 3
            }
        });
    }
}