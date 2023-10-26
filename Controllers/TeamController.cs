using CrossvilleCoed.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrossvilleCoed.Models;

[ApiController]
[Route("api/teams")]
public class GamesController : ControllerBase
{
    private CrossvilleCoedDbContext _dbcontext;
    public GamesController(CrossvilleCoedDbContext context)
    {
        _dbcontext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbcontext.Teams
        .Include(t => t.UserProfile)
        .ToList());
    }
}