using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Data;
using BudgetTracker.Models;

namespace BudgetTracker
{
    public class ExpenseDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public ExpenseDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ExpenseDetails
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ExpenseDetail.Include(e => e.Budget);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ExpenseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExpenseDetail == null)
            {
                return NotFound();
            }

            var expenseDetail = await _context.ExpenseDetail
                .Include(e => e.Budget)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseDetail == null)
            {
                return NotFound();
            }

            return View(expenseDetail);
        }

        // GET: ExpenseDetails/Create
        public IActionResult Create()
        {
            ViewData["BudgetId"] = new SelectList(_context.Budget, "Id", "Name");
            return View();
        }

        // POST: ExpenseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ExpectedAmount,ActualAmount,BudgetId")] ExpenseDetail expenseDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BudgetId"] = new SelectList(_context.Budget, "Id", "Name", expenseDetail.BudgetId);
            return View(expenseDetail);
        }

        // GET: ExpenseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExpenseDetail == null)
            {
                return NotFound();
            }

            var expenseDetail = await _context.ExpenseDetail.FindAsync(id);
            if (expenseDetail == null)
            {
                return NotFound();
            }
            ViewData["BudgetId"] = new SelectList(_context.Budget, "Id", "Name", expenseDetail.BudgetId);
            return View(expenseDetail);
        }

        // POST: ExpenseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ExpectedAmount,ActualAmount,BudgetId")] ExpenseDetail expenseDetail)
        {
            if (id != expenseDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseDetailExists(expenseDetail.Id))
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
            ViewData["BudgetId"] = new SelectList(_context.Budget, "Id", "Name", expenseDetail.BudgetId);
            return View(expenseDetail);
        }

        // GET: ExpenseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExpenseDetail == null)
            {
                return NotFound();
            }

            var expenseDetail = await _context.ExpenseDetail
                .Include(e => e.Budget)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseDetail == null)
            {
                return NotFound();
            }

            return View(expenseDetail);
        }

        // POST: ExpenseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExpenseDetail == null)
            {
                return Problem("Entity set 'AppDbContext.ExpenseDetail'  is null.");
            }
            var expenseDetail = await _context.ExpenseDetail.FindAsync(id);
            if (expenseDetail != null)
            {
                _context.ExpenseDetail.Remove(expenseDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseDetailExists(int id)
        {
          return (_context.ExpenseDetail?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
