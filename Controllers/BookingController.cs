using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using CarCleanz.Data;
using System.Threading.Tasks;

namespace CarCleanz.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (!ModelState.IsValid)
                return View(booking);

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Use nameof so refactors keep this correct
            return RedirectToAction(nameof(Success));
        }

        // Note PascalCase name
        [HttpGet]
        public IActionResult Success()
        {
            return View(); // looks for Views/Booking/Success.cshtml
        }
    }
}