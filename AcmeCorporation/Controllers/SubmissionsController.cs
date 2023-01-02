using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcmeCorporationNewDatabase;
using AcmeCorporation.Models;
using Microsoft.AspNetCore.Authorization;

namespace AcmeCorporation.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly AcmeCorporationContext _context;

        public SubmissionsController(AcmeCorporationContext context)
        {
            _context = context;
        }

        // GET: Submissions
        public async Task<IActionResult> Index()
        {
            return _context.Submission != null ?
                        View(await _context.Submission.ToListAsync()) :
                        Problem("Entity set 'AcmeCorporationContext.Submission'  is null.");
        }

        // GET: Submissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Submission == null)
            {
                return NotFound();
            }

            var submission = await _context.Submission
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // GET: Submissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Submissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,SerialNumber")] Submission submission)
        {
            var result = _context.SerialNumber.Where(x => x.ProductSerialNumber == submission.SerialNumber);
            var serialNumber = result.FirstOrDefault();

            if (serialNumber == null)
            {
                return View(submission);
            } 

            var numberOfTimesUsed = _context.Submission.Where(x => x.SerialNumber == submission.SerialNumber).Count();

            if(numberOfTimesUsed > 1)
            {
                ModelState.AddModelError("SerialNumber", "It seems you already used this number twice");
                submission.SerialNumber = Guid.Empty;           
                return View(submission);

            }

            if (ModelState.IsValid)
            {
                _context.Add(submission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(submission);
        }

        // GET: Submissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Submission == null)
            {
                return NotFound();
            }

            var submission = await _context.Submission.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }
            return View(submission);
        }

        // POST: Submissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailAdress,SerialNumber")] Submission submission)
        {
            if (id != submission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmissionExists(submission.Id))
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
            return View(submission);
        }

        // GET: Submissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Submission == null)
            {
                return NotFound();
            }

            var submission = await _context.Submission
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // POST: Submissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Submission == null)
            {
                return Problem("Entity set 'AcmeCorporationContext.Submission'  is null.");
            }
            var submission = await _context.Submission.FindAsync(id);
            if (submission != null)
            {
                _context.Submission.Remove(submission);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmissionExists(int id)
        {
            return (_context.Submission?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
