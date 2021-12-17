#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommuteTypeTracker.Model;

namespace CommuteTypeTracker.Controllers
{
    public class DailyCommutesController : Controller
    {
        private readonly CommuteTypeTrackerContext _context;

        public DailyCommutesController(CommuteTypeTrackerContext context)
        {
            _context = context;
        }

        // GET: DailyCommutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DailyCommute.ToListAsync());
        }

        // GET: DailyCommutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyCommute = await _context.DailyCommute
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyCommute == null)
            {
                return NotFound();
            }

            return View(dailyCommute);
        }

        // GET: DailyCommutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DailyCommutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateOfCmmute,CreatdAt,UpdatedAt,CommuteType")] DailyCommute dailyCommute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyCommute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dailyCommute);
        }

        // GET: DailyCommutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyCommute = await _context.DailyCommute.FindAsync(id);
            if (dailyCommute == null)
            {
                return NotFound();
            }
            return View(dailyCommute);
        }

        // POST: DailyCommutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfCmmute,CreatdAt,UpdatedAt,CommuteType")] DailyCommute dailyCommute)
        {
            if (id != dailyCommute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyCommute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyCommuteExists(dailyCommute.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dailyCommute);
        }

        // GET: DailyCommutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyCommute = await _context.DailyCommute
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyCommute == null)
            {
                return NotFound();
            }

            return View(dailyCommute);
        }

        // POST: DailyCommutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyCommute = await _context.DailyCommute.FindAsync(id);
            _context.DailyCommute.Remove(dailyCommute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyCommuteExists(int id)
        {
            return _context.DailyCommute.Any(e => e.Id == id);
        }
    }
}
