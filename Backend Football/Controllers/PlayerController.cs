using Backend_Football.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace Backend_Football.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlayerController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public PlayerController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var listPlayer = _context.Players.ToListAsync();
        return Ok(listPlayer.Result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        var player = await _context.Players.FindAsync(id);
        return Ok(player);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Player player)
    {
      try
      {
        _context.Add(player);
        await _context.SaveChangesAsync();
        return Ok(player);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message); 
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Player player)
    {
      try
      {
        if(id != player.Id)
          return NotFound();

        _context.Update(player);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Player updated." });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        var player = _context.Players.FirstOrDefault(x => x.Id == id);

        if(player == null)
          return NotFound();


        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Player deleted." });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }


  }
}
