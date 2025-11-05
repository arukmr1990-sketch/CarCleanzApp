using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using CarCleanz.Data;
using System.Linq;

namespace CarCleanzApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();

                ViewBag.BookingId = booking.Id;
                ViewBag.Name = booking.Name;
                ViewBag.Email = booking.Email;
                ViewBag.VehicleType = booking.VehicleType;
                ViewBag.ServiceType = booking.Service;
                ViewBag.BookingDate = booking.BookingDate.ToString("dd-MM-yyyy");
                ViewBag.Phone = booking.Phone;

                return View("Success", booking);
            }

            return View(booking);
        }

        // GET: Admin view
        public IActionResult Admin()
        {
            var bookings = _context.Bookings.ToList();
            return View(bookings);
        }
    }
}