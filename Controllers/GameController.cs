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

    [HttpPost]
    public IActionResult AddGame([FromBody] Game game)
    {
        if (game == null)
        {
            return BadRequest("Invalid game data");
        }

        if (ModelState.IsValid)
        {
            try
            {
                var homeTeamExists = _dbcontext.Teams.Any(t => t.Id == game.HomeTeamId);
                var visitorTeamExists = _dbcontext.Teams.Any(t => t.Id == game.VisitorTeamId);

                if (!homeTeamExists || !visitorTeamExists)
                {
                    return BadRequest("One or both of the specified teams do not exist.");
                }

                _dbcontext.Games.Add(game);
                _dbcontext.SaveChanges();

                return Ok("Game added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        else
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(errors);
        }
    }

}