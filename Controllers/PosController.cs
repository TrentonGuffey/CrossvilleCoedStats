using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CrossvilleCoed.Data;
using Microsoft.EntityFrameworkCore;
using CrossvilleCoed.Models;

namespace CrossvilleCoed.Controllers;

[ApiController]
[Route("api/positions")]
public class PositionsController : ControllerBase
{
    private CrossvilleCoedDbContext _dbcontext;

    public PositionsController(CrossvilleCoedDbContext context)
    {
        _dbcontext = context;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dbcontext.Positions
        .ToList());
    }
}