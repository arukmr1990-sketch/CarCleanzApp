using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using CarCleanz.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CarCleanz.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ? GET: /Booking/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
[HttpGet]
public IActionResult Index()
{
    // Redirect /Booking to /Booking/Create
    return RedirectToAction("Create");
}

        // ? POST: /Booking/Create
        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Booking booking)
{
    if (ModelState.IsValid)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();

        // ? Pass the booking ID to Success page
        return RedirectToAction("Success", new { id = booking.Id });
    }
    return View(booking);
}

       public IActionResult Success(int id)
{
    var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
    if (booking == null)
    {
        return RedirectToAction("Create");
    }

    return View(booking);
}
[HttpGet]
public IActionResult Admin()
{
    if (HttpContext.Session.GetString("IsAdmin") != "true")
    {
        return RedirectToAction("Login", "Admin");
    }

    var bookings = _context.Bookings.ToList();
    return View(bookings);
}

    }
// ? GET: /Booking/Admin

}