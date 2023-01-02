using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcmeCorporationNewDatabase;
using AcmeCorporation.Models;

namespace AcmeCorporation.Controllers
{
    public class SerialNumbersController : Controller
    {
        private readonly AcmeCorporationContext _context;

        public SerialNumbersController(AcmeCorporationContext context)
        {
            _context = context;
        }

        // GET: SerialNumbers
        public async Task<IActionResult> Index()
        {
              return _context.SerialNumber != null ? 
                          View(await _context.SerialNumber.ToListAsync()) :
                          Problem("Entity set 'AcmeCorporationContext.SerialNumber'  is null.");
        }

        // GET: SerialNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SerialNumber == null)
            {
                return NotFound();
            }

            var serialNumber = await _context.SerialNumber
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serialNumber == null)
            {
                return NotFound();
            }

            return View(serialNumber);
        }

        // GET: SerialNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SerialNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductSerialNumber")] SerialNumber serialNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serialNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serialNumber);
        }

        // GET: SerialNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SerialNumber == null)
            {
                return NotFound();
            }

            var serialNumber = await _context.SerialNumber.FindAsync(id);
            if (serialNumber == null)
            {
                return NotFound();
            }
            return View(serialNumber);
        }

        // POST: SerialNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductSerialNumber")] SerialNumber serialNumber)
        {
            if (id != serialNumber.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serialNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerialNumberExists(serialNumber.ID))
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
            return View(serialNumber);
        }

        // GET: SerialNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SerialNumber == null)
            {
                return NotFound();
            }

            var serialNumber = await _context.SerialNumber
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serialNumber == null)
            {
                return NotFound();
            }

            return View(serialNumber);
        }

        // POST: SerialNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SerialNumber == null)
            {
                return Problem("Entity set 'AcmeCorporationContext.SerialNumber'  is null.");
            }
            var serialNumber = await _context.SerialNumber.FindAsync(id);
            if (serialNumber != null)
            {
                _context.SerialNumber.Remove(serialNumber);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SerialNumberExists(int id)
        {
          return (_context.SerialNumber?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}