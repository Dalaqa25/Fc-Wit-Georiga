using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WitGeorgia.Data;
using WitGeorgia.Dtos;
using WitGeorgia.Model;

namespace WitGeorgia.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public PlayersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var playerModel = await _context.Players.ToListAsync();

        if (playerModel == null)
        {
            return NotFound();
        }

        return Ok(playerModel);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetPlayerById(int id)
    {
        var playerModel = await _context.Players.FindAsync(id);

        if (playerModel == null)
        {
            return NotFound();
        }

        return Ok(playerModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePlayerDto createPlayerDto)
    {
        if (createPlayerDto == null)
            return BadRequest("PlayerDto is null");
        
        //Map DTO to Entity
        var player = new Player
        {
            FirstName = createPlayerDto.FirstName,
            LastName = createPlayerDto.LastName,
            PersonalNumber = createPlayerDto.PersonalNumber,
            Salary = createPlayerDto.Salary,
            PhoneNumber = createPlayerDto.PhoneNumber,
            Birthday = createPlayerDto.Birthday,
            CreatedDate = DateTime.UtcNow // Automatically set creation date
        };
        
        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, createPlayerDto);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
        var playerModel = await _context.Players.FindAsync(id);
        
        if (playerModel == null)
            return NotFound("Player not found");
        
        // Set the DeletedDate for the player
        playerModel.DeletedDate = DateTime.UtcNow;
        
        // Create delte player object
        var deltedPlayer = new DeletedPlayers
        {
            FirstName = playerModel.FirstName,
            LastName = playerModel.LastName,
            Birthday = playerModel.Birthday,
            DeletedDate = playerModel.DeletedDate
        };
        
        // Add deleted players to deleted players table
        _context.DeletedPlayers.Add(deltedPlayer);
        await _context.SaveChangesAsync();
        
        _context.Players.Remove(playerModel);
        await _context.SaveChangesAsync();
        
        return Ok(new { Message = "Player deleted successfully", DeletedPlayers = deltedPlayer.DeletedDate });
    }
    
    // if player DNE return to found
    // Make everything what should be updated
    // Save changes

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlayer([FromRoute] int id, [FromBody] UpdatePlayerDto updatePlayerDto)
    {
        var playerModel = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);

        if (playerModel == null)
            return NotFound();
        
        playerModel.Salary = updatePlayerDto.Salary;
        playerModel.PhoneNumber = updatePlayerDto.PhoneNumber;
        
        await _context.SaveChangesAsync();

        return Ok(playerModel);
    }

}