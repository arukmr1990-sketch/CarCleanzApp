using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CarCleanz.Models;
using CarCleanz.Data;
using System.Collections.Generic;
using System.Linq;

namespace CarCleanzApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        // ✅ Inject the database context
        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking form
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                // ✅ Save booking into database
                _context.Bookings.Add(booking);
                _context.SaveChanges();

                return RedirectToAction("Success");
            }

            // If invalid, re-show the form with validation messages
            return View("Index", booking);
        }

        public IActionResult Success()
        {
            return View();
        }

        // ✅ Admin View
        public IActionResult Admin()
        {
            if (HttpContext.Session.GetString("IsAdminLoggedIn") != "true")
            {
                return RedirectToAction("Login", "Admin");
            }

            // ✅ Fetch bookings from DB instead of static list
            var bookings = _context.Bookings.ToList();
            return View(bookings);
        }
    }
}
