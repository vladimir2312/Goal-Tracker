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

        // GET: /Goals
        public async Task<IActionResult> Index()
        {
            var goals = await _db.Goals.ToListAsync();
            return View(goals);
        }

        // GET: /Goals/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var goal = await _db.Goals.FirstOrDefaultAsync(g => g.Id == id);
            if (goal == null) return NotFound();
            return View(goal);
        }

        // GET: /Goals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Goals/Create
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

        // POST: /Goals/AddProgress/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProgress(int id, double value)
        {
            var goal = await _db.Goals.FindAsync(id);
            if (goal == null) return NotFound();

            goal.CurrentValue = value;
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = id });
        }

        // POST: /Goals/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var goal = await _db.Goals.FindAsync(id);
            if (goal != null)
            {
                _db.Goals.Remove(goal);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
