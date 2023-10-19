using CrossvilleCoed.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrossvilleCoed.Models;


namespace CrossvilleCoed.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController : ControllerBase
{
    private CrossvilleCoedDbContext _dbcontext;
    public GamesController(CrossvilleCoedDbContext context)
    {
        _dbcontext = context;
    }

    [HttpGet]
    //[Authorize]

    public IActionResult Get()
    {
        return Ok(_dbcontext.Games
        .Include(g => g.HomeTeam)
        .Include(g => g.VisitorTeam)
        .ToList());
    }
}