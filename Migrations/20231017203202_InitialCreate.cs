using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Capstone.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pos = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeTeamId = table.Column<int>(type: "integer", nullable: false),
                    VisitorTeamId = table.Column<int>(type: "integer", nullable: false),
                    GameTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Teams_VisitorTeamId",
                        column: x => x.VisitorTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    TotalPlateAppearances = table.Column<double>(type: "double precision", nullable: false),
                    Single = table.Column<int>(type: "integer", nullable: false),
                    Double = table.Column<int>(type: "integer", nullable: false),
                    Triple = table.Column<int>(type: "integer", nullable: false),
                    HomeRun = table.Column<int>(type: "integer", nullable: false),
                    Walk = table.Column<int>(type: "integer", nullable: false),
                    Sacrifice = table.Column<int>(type: "integer", nullable: false),
                    FieldersChoice = table.Column<int>(type: "integer", nullable: false),
                    RunsBattedIn = table.Column<int>(type: "integer", nullable: false),
                    RunsScored = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d373bd0-c738-40ee-bff1-b135b40a7be9", null, "Coach", "coach" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "01ccfa71-2781-48bf-8e35-196e48859662", 0, "dedf6179-99dc-4640-b0b8-dd5aa8b71b17", "Camie.Miller@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEHBwdvUpD2Ol7WFtGpzKrnDdeybcNzy2kKQqnm9JJAj+/SpnToDil7Lbicj+OcZs3Q==", null, false, "de65b1d4-c560-4585-8168-9feb99b141d6", false, "FairOaksFarms" },
                    { "4eeea886-15a8-46d0-a26b-57ed40a5ee0a", 0, "d696831a-6bf6-484f-a598-aca99181fbf4", "Wayne.Burns@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMrcQQbE5HoplPfWSOGIJosFbfN8uIPJCCN0ogLH36ABdJSU4P9xsEWZ8inqR0NWPw==", null, false, "bc12e288-a57a-43d6-bce5-1127753fa9ac", false, "CampbellsPestControl" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "28d5d196-d7df-47d7-9a44-9928a389c350", "tjguffey50@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEOaInbx3pX1Kh9kh3VrjIZZ92PijQIVMdllXpeJilFryjl0MQYrSTEK9N82dL7QfyQ==", null, false, "4321f44c-9c4d-449a-afea-3278d966e888", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Pos" },
                values: new object[,]
                {
                    { 1, "P" },
                    { 2, "C" },
                    { 3, "1B" },
                    { 4, "2B" },
                    { 5, "3B" },
                    { 6, "SS" },
                    { 7, "OF" },
                    { 8, "EH" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1d373bd0-c738-40ee-bff1-b135b40a7be9", "01ccfa71-2781-48bf-8e35-196e48859662" },
                    { "1d373bd0-c738-40ee-bff1-b135b40a7be9", "4eeea886-15a8-46d0-a26b-57ed40a5ee0a" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "Trenton", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Guffey" },
                    { 2, "Camie", "01ccfa71-2781-48bf-8e35-196e48859662", "Miller" },
                    { 3, "Wayne", "4eeea886-15a8-46d0-a26b-57ed40a5ee0a", "Burns" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name", "UserProfileId" },
                values: new object[,]
                {
                    { 1, "Fair Oaks Farms", 2 },
                    { 2, "Campbells Pest Control", 3 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GameTime", "HomeTeamId", "VisitorTeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 2, 18, 15, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 2, new DateTime(2023, 10, 5, 19, 15, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 3, new DateTime(2023, 10, 9, 18, 15, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 4, new DateTime(2023, 10, 12, 19, 15, 0, 0, DateTimeKind.Unspecified), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "FirstName", "LastName", "PositionId", "TeamId" },
                values: new object[,]
                {
                    { 1, "Trenton", "Guffey", 1, 1 },
                    { 2, "Ethan", "Todd", 6, 1 },
                    { 3, "Tyler", "Richardson", 7, 1 },
                    { 4, "Camie", "Miller", 7, 1 },
                    { 5, "John aka Paco", "Rolan", 1, 1 },
                    { 6, "Jonathan", "Stout", 5, 1 },
                    { 7, "Karli", "Threet", 3, 1 },
                    { 8, "Riley", "Norris", 7, 1 },
                    { 9, "Scottie", "Payne", 2, 1 },
                    { 10, "Tori", "Stout", 4, 1 },
                    { 11, "Chandler", "Hardwick", 7, 1 },
                    { 12, "Jade", "Payne", 4, 1 },
                    { 13, "Chance", "Clark", 1, 2 },
                    { 14, "Wayne", "Burns", 1, 2 },
                    { 15, "Justin", "Timmons", 6, 2 },
                    { 16, "Russell", "Campbell", 7, 2 },
                    { 17, "Dora", "Erazocordova", 2, 2 },
                    { 18, "Destiny", "Ruppe", 7, 2 },
                    { 19, "Brent", "Bowman", 1, 2 },
                    { 20, "Jessica", "Lancianese", 3, 2 },
                    { 21, "Kendall", "Cooper", 7, 2 },
                    { 22, "Nick", "Bowman", 5, 2 },
                    { 23, "Chris", "Patton", 5, 2 },
                    { 24, "Christa", "Wendig", 4, 2 },
                    { 25, "Joseph", "Haley", 7, 2 },
                    { 26, "Justin", "Carr", 7, 2 },
                    { 27, "Tanner", "Hurd", 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "PlayerGames",
                columns: new[] { "Id", "Double", "FieldersChoice", "GameId", "HomeRun", "PlayerId", "RunsBattedIn", "RunsScored", "Sacrifice", "Single", "TotalPlateAppearances", "Triple", "Walk" },
                values: new object[,]
                {
                    { 1, 2, 0, 1, 0, 15, 2, 4, 0, 2, 4.0, 0, 0 },
                    { 2, 2, 0, 1, 1, 25, 3, 4, 0, 2, 4.0, 0, 0 },
                    { 3, 0, 0, 1, 1, 22, 3, 3, 0, 2, 4.0, 0, 0 },
                    { 4, 0, 0, 1, 0, 24, 2, 2, 0, 2, 4.0, 0, 0 },
                    { 5, 0, 0, 1, 1, 23, 3, 3, 0, 2, 4.0, 0, 0 },
                    { 6, 0, 0, 1, 0, 18, 1, 2, 0, 2, 4.0, 0, 0 },
                    { 7, 2, 0, 1, 0, 19, 3, 1, 0, 1, 4.0, 0, 0 },
                    { 8, 1, 0, 1, 0, 26, 1, 1, 0, 1, 3.0, 0, 0 },
                    { 9, 0, 0, 1, 0, 17, 1, 0, 0, 1, 3.0, 0, 0 },
                    { 10, 0, 0, 1, 0, 14, 3, 2, 0, 2, 3.0, 0, 0 },
                    { 11, 2, 0, 1, 0, 3, 2, 3, 0, 2, 3.0, 0, 0 },
                    { 12, 0, 1, 1, 0, 7, 0, 2, 0, 1, 4.0, 0, 1 },
                    { 13, 0, 0, 1, 0, 2, 2, 1, 0, 0, 4.0, 1, 0 },
                    { 14, 2, 0, 1, 0, 8, 4, 2, 0, 0, 4.0, 1, 0 },
                    { 15, 1, 0, 1, 0, 10, 2, 1, 0, 2, 4.0, 0, 0 },
                    { 16, 0, 1, 1, 0, 9, 1, 1, 0, 2, 4.0, 0, 0 },
                    { 17, 0, 0, 1, 0, 1, 1, 1, 0, 3, 4.0, 0, 0 },
                    { 18, 1, 0, 1, 0, 4, 1, 1, 0, 0, 4.0, 0, 0 },
                    { 19, 1, 0, 1, 2, 5, 4, 3, 0, 0, 4.0, 0, 0 },
                    { 20, 2, 0, 1, 0, 11, 2, 3, 0, 1, 3.0, 0, 0 },
                    { 21, 0, 0, 1, 1, 6, 2, 2, 0, 2, 3.0, 0, 0 },
                    { 22, 2, 0, 2, 0, 15, 2, 2, 0, 2, 4.0, 0, 0 },
                    { 23, 2, 0, 2, 1, 25, 3, 4, 0, 1, 4.0, 0, 0 },
                    { 24, 0, 0, 2, 2, 22, 3, 4, 0, 2, 4.0, 0, 0 },
                    { 25, 0, 0, 2, 0, 24, 2, 3, 0, 2, 4.0, 0, 0 },
                    { 26, 0, 0, 2, 1, 23, 3, 3, 0, 2, 4.0, 0, 0 },
                    { 27, 0, 0, 2, 0, 18, 2, 2, 0, 2, 4.0, 0, 0 },
                    { 28, 0, 0, 2, 0, 19, 3, 3, 0, 2, 4.0, 0, 0 },
                    { 29, 0, 0, 2, 0, 26, 2, 2, 0, 2, 3.0, 0, 0 },
                    { 30, 0, 0, 2, 0, 17, 1, 0, 0, 1, 3.0, 0, 0 },
                    { 31, 0, 0, 2, 0, 14, 3, 2, 0, 2, 3.0, 0, 0 },
                    { 32, 2, 0, 2, 0, 3, 2, 3, 0, 2, 4.0, 0, 0 },
                    { 33, 0, 0, 2, 0, 7, 0, 1, 0, 1, 4.0, 0, 3 },
                    { 34, 0, 0, 2, 0, 2, 1, 1, 0, 0, 4.0, 1, 0 },
                    { 35, 2, 0, 2, 0, 8, 4, 2, 0, 0, 4.0, 1, 0 },
                    { 36, 1, 0, 2, 0, 10, 2, 1, 0, 2, 4.0, 0, 0 },
                    { 37, 0, 0, 2, 1, 1, 1, 1, 0, 3, 4.0, 0, 0 },
                    { 38, 1, 0, 2, 0, 4, 1, 1, 0, 0, 4.0, 0, 0 },
                    { 39, 1, 0, 2, 2, 5, 4, 3, 0, 0, 4.0, 0, 0 },
                    { 40, 2, 0, 2, 0, 11, 2, 3, 0, 1, 3.0, 0, 0 },
                    { 41, 0, 0, 2, 1, 6, 2, 3, 0, 2, 3.0, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_VisitorTeamId",
                table: "Games",
                column: "VisitorTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_GameId",
                table: "PlayerGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayerId",
                table: "PlayerGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserProfileId",
                table: "Teams",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
