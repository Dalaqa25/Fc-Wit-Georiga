using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WitGeorgiaMVC.Data;
using WitGeorgiaMVC.Dtos;
using WitGeorgiaMVC.Models;
using WitGeorgiaMVC.ViewsModel;

namespace WitGeorgiaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var player = await _context.Players.ToListAsync();
            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Player playerViewModel)
        {
            if (ModelState.IsValid)
            {
                var player = new Player
                {
                    FirstName = playerViewModel.FirstName,
                    LastName = playerViewModel.LastName,
                    CreatedDate = DateTime.UtcNow,
                    Salary = playerViewModel.Salary,
                    PhoneNumber = playerViewModel.PhoneNumber,
                    PersonalNumber = playerViewModel.PersonalNumber
                };

                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerViewModel);
        }
        
        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            var playerViewModel = new Player
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Salary = player.Salary,
                PhoneNumber = player.PhoneNumber
            };

            return View(playerViewModel);
        }
        
        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }
        
        
        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Players.FindAsync(id);
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
