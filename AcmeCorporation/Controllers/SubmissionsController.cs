using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcmeCorporation.Data;
using AcmeCorporation.Models;

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
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,SerialNumber,Birthdate")] Submission submission)
        {
            //Computing age
            var today = DateTime.Today;
            var birthDate = submission.Birthdate;
            var age = today.Year - birthDate.Year;

            if(birthDate.Month > today.Month || birthDate.Month == today.Month && birthDate.Date > today.Date)
            {
                age--;
            } 

            if(age < 18)
            {
                ModelState.AddModelError("Birthdate", "You must be 18 to enter");
                return View(submission);
            }

            

            // Check if serial exists
            var result = _context.SerialNumber.Where(x => x.ProductSerialNumber == submission.SerialNumber);
            var serialNumber = result.FirstOrDefault();

            if (serialNumber == null)
            {
                ModelState.AddModelError("SerialNumber", "It seems this serial number does not exist");
                return View(submission);
            }

            var numberOfTimesUsed = _context.Submission.Where(x => x.SerialNumber == submission.SerialNumber).Count();

            if (numberOfTimesUsed > 1)
            {
                ModelState.AddModelError("SerialNumber", "It seems you already used this number twice");
                return View(submission);

            }

            if (ModelState.IsValid)
            {
                _context.Add(submission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Confirmation));
            }
            return View(submission);
        }

        public IActionResult Confirmation()
        {
            return View();
        }

    }
}
