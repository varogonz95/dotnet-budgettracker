using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Data;
using BudgetTracker.Models;

namespace BudgetTracker.Controllers
{
    public class BudgetsController : Controller
    {
        private readonly AppDbContext _context;

        public BudgetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Budgets
        public async Task<IActionResult> Index()
        {
              return _context.Budget != null ? 
                          View(await _context.Budget.ToListAsync()) :
                          Problem("Entity set 'BudgetTrackerContext.Budget'  is null.");
        }

        // GET: Budgets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Budget == null)
            {
                return NotFound();
            }

            var budget = await _context.Budget
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // GET: Budgets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Amount")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budget);
        }

        // GET: Budgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Budget == null)
            {
                return NotFound();
            }

            var budget = await _context.Budget.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            return View(budget);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Amount")] Budget budget)
        {
            if (id != budget.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetExists(budget.Id))
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
            return View(budget);
        }

        // GET: Budgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Budget == null)
            {
                return NotFound();
            }

            var budget = await _context.Budget
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Budget == null)
            {
                return Problem("Entity set 'BudgetTrackerContext.Budget'  is null.");
            }
            var budget = await _context.Budget.FindAsync(id);
            if (budget != null)
            {
                _context.Budget.Remove(budget);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetExists(int id)
        {
          return (_context.Budget?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
