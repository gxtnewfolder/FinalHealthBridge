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
    public class HealthcareProvidersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HealthcareProvidersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HealthcareProviders
        public async Task<IActionResult> Index()
        {
              return _context.HealthcareProvider != null ? 
                          View(await _context.HealthcareProvider.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HealthcareProvider'  is null.");
        }

        // GET: HealthcareProviders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HealthcareProvider == null)
            {
                return NotFound();
            }

            var healthcareProvider = await _context.HealthcareProvider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthcareProvider == null)
            {
                return NotFound();
            }

            return View(healthcareProvider);
        }

        // GET: HealthcareProviders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthcareProviders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProviderName,Specialy,Contact")] HealthcareProvider healthcareProvider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthcareProvider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthcareProvider);
        }

        // GET: HealthcareProviders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HealthcareProvider == null)
            {
                return NotFound();
            }

            var healthcareProvider = await _context.HealthcareProvider.FindAsync(id);
            if (healthcareProvider == null)
            {
                return NotFound();
            }
            return View(healthcareProvider);
        }

        // POST: HealthcareProviders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProviderName,Specialy,Contact")] HealthcareProvider healthcareProvider)
        {
            if (id != healthcareProvider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthcareProvider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthcareProviderExists(healthcareProvider.Id))
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
            return View(healthcareProvider);
        }

        // GET: HealthcareProviders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HealthcareProvider == null)
            {
                return NotFound();
            }

            var healthcareProvider = await _context.HealthcareProvider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthcareProvider == null)
            {
                return NotFound();
            }

            return View(healthcareProvider);
        }

        // POST: HealthcareProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HealthcareProvider == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HealthcareProvider'  is null.");
            }
            var healthcareProvider = await _context.HealthcareProvider.FindAsync(id);
            if (healthcareProvider != null)
            {
                _context.HealthcareProvider.Remove(healthcareProvider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthcareProviderExists(int id)
        {
          return (_context.HealthcareProvider?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
