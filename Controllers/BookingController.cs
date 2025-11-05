using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using CarCleanz.Data;

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
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();

                // Redirect to Success page after saving
                return RedirectToAction("success");
            }

            // If validation fails, reload the form
            return View(booking);
        }

        public IActionResult success()
        {
            return View();
        }
    }
}