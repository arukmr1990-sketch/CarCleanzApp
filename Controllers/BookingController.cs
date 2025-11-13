using Microsoft.AspNetCore.Mvc;
using CarCleanz.Data;
using CarCleanz.Models;
using System.Linq;

namespace CarCleanz.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
[HttpPost]
public IActionResult Create(Booking booking)
{
    if (!ModelState.IsValid)
        {
        // Get last booking
        var lastBooking = _context.Bookings
            .OrderByDescending(b => b.Id)
            .FirstOrDefault();

        int nextNumber = 3000; // starting number

        if (lastBooking != null && !string.IsNullOrEmpty(lastBooking.CustomBookingId))
        {
            // extract number from "CCA3000"
            string numberPart = lastBooking.CustomBookingId.Replace("CCA", "");
            nextNumber = int.Parse(numberPart) + 1;
        }

        // Assign new booking ID
        booking.CustomBookingId = $"CCA{nextNumber}";

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return RedirectToAction("Success");
    }

    return View(booking);
}

    switch ((booking.VehicleType ?? "").ToLower())
    {
        case "hatchback":
            booking.Price = 499;
            break;
        case "sedan":
            booking.Price = 650;
            break;
        case "suv":
            booking.Price = 750;
            break;
        default:
            booking.Price = 0;
            break;
    }

    _context.Bookings.Add(booking);
    _context.SaveChanges();

    return RedirectToAction("Payment", new { id = booking.Id });
}        

        // GET: Booking/Payment?id=5
        public IActionResult Payment(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();

            // Show the payment page with model
            return View(booking);
        }

        // GET: Booking/Success?id=5
        public IActionResult Success(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();

            return View(booking);
        }
    }
}