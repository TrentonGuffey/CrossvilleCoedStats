using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CrossvilleCoed.Data;
using Microsoft.EntityFrameworkCore;
using CrossvilleCoed.Models;

namespace CrossvilleCoed.Controllers;

[ApiController]
[Route("api/playergames")]
public class PlayerGameController : ControllerBase
{
    private CrossvilleCoedDbContext _dbcontext;

    public PlayerGameController(CrossvilleCoedDbContext context)
    {
        _dbcontext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbcontext.PlayerGames
            .Include(pg => pg.Player)
                .ThenInclude(p => p.Team)
            .Include(pg => pg.Game)
            .ToList());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddPlayerGame([FromBody] PlayerGame playerGame)
    {
        if (playerGame == null)
        {
            return BadRequest("Invalid data");
        }

        _dbcontext.PlayerGames.Add(playerGame);
        await _dbcontext.SaveChangesAsync();

        return Ok("Player game stats added successfully");
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        try
        {
            var playerGame = _dbcontext.PlayerGames.Find(id);

            if (playerGame == null)
            {
                return NotFound();
            }
            _dbcontext.PlayerGames.Remove(playerGame);
            _dbcontext.SaveChanges();

            return NoContent();
        }
                catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }

    }

}