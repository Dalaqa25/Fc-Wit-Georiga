using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WitGeorgiaMVC.Data;

namespace WitGeorgiaMVC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeletedPlayerController: ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public DeletedPlayerController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetDeletedPlayers()
    {
        var deletedPlayerModel = await _context.DeletedPlayers.ToListAsync();

        if (deletedPlayerModel == null)
            return NotFound();
        
        return Ok(deletedPlayerModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDeletedPlayerById([FromRoute] int id)
    {
        var deletedPlayerModel = await _context.DeletedPlayers.FindAsync(id);

        if (deletedPlayerModel == null)
            return NotFound();

        return Ok(deletedPlayerModel);
    }
}