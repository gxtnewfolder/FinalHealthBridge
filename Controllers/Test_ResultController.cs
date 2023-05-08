using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalHealthBridge.Data;
using FinalHealthBridge.Models;

namespace FinalHealthBridge.Controllers
{
    public class Test_ResultController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Test_ResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Test_Result
        public async Task<IActionResult> Index()
        {
              return _context.Test_Result != null ? 
                          View(await _context.Test_Result.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Test_Result'  is null.");
        }

        // GET: Test_Result/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Test_Result == null)
            {
                return NotFound();
            }

            var test_Result = await _context.Test_Result
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test_Result == null)
            {
                return NotFound();
            }

            return View(test_Result);
        }

        // GET: Test_Result/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Test_Result/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,TestName,TestDate,Result")] Test_Result test_Result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(test_Result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(test_Result);
        }

        // GET: Test_Result/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Test_Result == null)
            {
                return NotFound();
            }

            var test_Result = await _context.Test_Result.FindAsync(id);
            if (test_Result == null)
            {
                return NotFound();
            }
            return View(test_Result);
        }

        // POST: Test_Result/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PatientId,TestName,TestDate,Result")] Test_Result test_Result)
        {
            if (id != test_Result.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test_Result);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Test_ResultExists(test_Result.Id))
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
            return View(test_Result);
        }

        // GET: Test_Result/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Test_Result == null)
            {
                return NotFound();
            }

            var test_Result = await _context.Test_Result
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test_Result == null)
            {
                return NotFound();
            }

            return View(test_Result);
        }

        // POST: Test_Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Test_Result == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Test_Result'  is null.");
            }
            var test_Result = await _context.Test_Result.FindAsync(id);
            if (test_Result != null)
            {
                _context.Test_Result.Remove(test_Result);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Test_ResultExists(long id)
        {
          return (_context.Test_Result?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
