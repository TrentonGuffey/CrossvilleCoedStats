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

    [HttpDelete("{id}")]
    //[Authorize]
    public IActionResult Delete(int id)
    {
        try
        {
            var game = _dbcontext.Games.Find(id);

            if (game == null)
            {
                return NotFound();
            }

            _dbcontext.Games.Remove(game);
            _dbcontext.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

}