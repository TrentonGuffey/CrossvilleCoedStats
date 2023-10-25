using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CrossvilleCoed.Data;
using Microsoft.EntityFrameworkCore;
using CrossvilleCoed.Models;

namespace CrossvilleCoed.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private CrossvilleCoedDbContext _dbcontext;

    public PlayersController(CrossvilleCoedDbContext context)
    {
        _dbcontext = context;
    }

    [HttpGet]
    //[Authorize]
    public IActionResult Get()
    {
        return Ok(_dbcontext.Players
        .Include(p => p.Team)
        .Include(p => p.Pos)
        .Include(p => p.PlayerGames)
        .ToList());
    }

    [HttpGet("{id}")]
    //[Authorize]
    public IActionResult GetById(int id)
    {
        Player player = _dbcontext.Players
            .Include(p => p.Team)
            .Include(p => p.Pos)
            .Include(p => p.PlayerGames)
                .ThenInclude(pg => pg.Game)
            .SingleOrDefault(p => p.Id == id);
        
        if (player == null)
        {
            return NotFound();
        }

        return Ok(player);
    }

    [HttpDelete("{id}")]
    //[Authorize]
    public IActionResult Delete(int id)
    {
        try
        {
            var player = _dbcontext.Players.Find(id);

            if (player == null)
            {
                return NotFound(); 
            }

            _dbcontext.Players.Remove(player);
            _dbcontext.SaveChanges();

            return NoContent(); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}"); 
        }
    }

    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> Register([FromBody] Player player)
    {
        if (player == null)
        {
            return BadRequest("Invalid data");
        }

        _dbcontext.Players.Add(player);
        await _dbcontext.SaveChangesAsync();

        return Ok("Player added successfully");
    }

    [HttpPut("{id}/editTeam")]
    //[Authorize]
    public async Task<IActionResult> EditTeam([FromBody] Player player)
    {
        if (player == null)
        {
            return BadRequest("Invalid data");
        }

        try
        {
            var existingPlayer = _dbcontext.Players.FirstOrDefault(p => p.Id == player.Id);

            if (existingPlayer == null)
            {
                return NotFound("Player not found");
            }
            existingPlayer.TeamId = player.TeamId;
            _dbcontext.SaveChanges();
            return Ok("Player's team updated successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating player's team: " + ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}
