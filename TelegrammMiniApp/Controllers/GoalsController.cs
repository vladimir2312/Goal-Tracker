using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelegrammMiniApp.Data;
using TelegrammMiniApp.Models;

namespace TelegrammMiniApp.Controllers
{
    public class GoalsController : Controller
    {
       private readonly AppDbContext _db;

        public GoalsController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index() {

            var goals = await _db.Goals.ToListAsync();
            return View(goals);
        }     
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Goal goal)
        {
            if (ModelState.IsValid)
            {
                _db.Goals.Add(goal);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goal);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var goal = await _db.Goals.FirstOrDefaultAsync(g => g.Id == id);
            if (goal == null) return NotFound();
            return View(goal);
        }
    }
}
