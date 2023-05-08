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
    public class Treatment_PlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Treatment_PlanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Treatment_Plan
        public async Task<IActionResult> Index()
        {
              return _context.Treatment_Plan != null ? 
                          View(await _context.Treatment_Plan.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Treatment_Plan'  is null.");
        }

        // GET: Treatment_Plan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Treatment_Plan == null)
            {
                return NotFound();
            }

            var treatment_Plan = await _context.Treatment_Plan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatment_Plan == null)
            {
                return NotFound();
            }

            return View(treatment_Plan);
        }

        // GET: Treatment_Plan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treatment_Plan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,Diagnosis,Treatment_Description")] Treatment_Plan treatment_Plan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treatment_Plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treatment_Plan);
        }

        // GET: Treatment_Plan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Treatment_Plan == null)
            {
                return NotFound();
            }

            var treatment_Plan = await _context.Treatment_Plan.FindAsync(id);
            if (treatment_Plan == null)
            {
                return NotFound();
            }
            return View(treatment_Plan);
        }

        // POST: Treatment_Plan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,Diagnosis,Treatment_Description")] Treatment_Plan treatment_Plan)
        {
            if (id != treatment_Plan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatment_Plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Treatment_PlanExists(treatment_Plan.Id))
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
            return View(treatment_Plan);
        }

        // GET: Treatment_Plan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Treatment_Plan == null)
            {
                return NotFound();
            }

            var treatment_Plan = await _context.Treatment_Plan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatment_Plan == null)
            {
                return NotFound();
            }

            return View(treatment_Plan);
        }

        // POST: Treatment_Plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Treatment_Plan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Treatment_Plan'  is null.");
            }
            var treatment_Plan = await _context.Treatment_Plan.FindAsync(id);
            if (treatment_Plan != null)
            {
                _context.Treatment_Plan.Remove(treatment_Plan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Treatment_PlanExists(int id)
        {
          return (_context.Treatment_Plan?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
