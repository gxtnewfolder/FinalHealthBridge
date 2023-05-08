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
    public class Medical_HistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Medical_HistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medical_History
        public async Task<IActionResult> Index()
        {
              return _context.Medical_History != null ? 
                          View(await _context.Medical_History.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Medical_History'  is null.");
        }

        // GET: Medical_History/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medical_History == null)
            {
                return NotFound();
            }

            var medical_History = await _context.Medical_History
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medical_History == null)
            {
                return NotFound();
            }

            return View(medical_History);
        }

        // GET: Medical_History/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medical_History/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,Diagnosis,chronic_diseases,allergies")] Medical_History medical_History)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medical_History);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medical_History);
        }

        // GET: Medical_History/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medical_History == null)
            {
                return NotFound();
            }

            var medical_History = await _context.Medical_History.FindAsync(id);
            if (medical_History == null)
            {
                return NotFound();
            }
            return View(medical_History);
        }

        // POST: Medical_History/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,Diagnosis,chronic_diseases,allergies")] Medical_History medical_History)
        {
            if (id != medical_History.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medical_History);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Medical_HistoryExists(medical_History.Id))
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
            return View(medical_History);
        }

        // GET: Medical_History/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medical_History == null)
            {
                return NotFound();
            }

            var medical_History = await _context.Medical_History
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medical_History == null)
            {
                return NotFound();
            }

            return View(medical_History);
        }

        // POST: Medical_History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medical_History == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Medical_History'  is null.");
            }
            var medical_History = await _context.Medical_History.FindAsync(id);
            if (medical_History != null)
            {
                _context.Medical_History.Remove(medical_History);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Medical_HistoryExists(int id)
        {
          return (_context.Medical_History?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
