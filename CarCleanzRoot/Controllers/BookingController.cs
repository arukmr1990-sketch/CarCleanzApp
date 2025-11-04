using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using System.Collections.Generic;
using CarCleanz.Data;

namespace CarCleanzApp.Controllers
{
    public class BookingController : Controller
    {
        private static List<Booking> bookings = new List<Booking>();

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
        _context.Bookings.Add(booking);  // Save booking into database
        _context.SaveChanges();          // Commit the transaction
        return RedirectToAction("Success");
    }

    return View("Index", booking); // return back with validation errors
}


        public IActionResult Success()
        {
            return View();
        }

        // Admin View
        public IActionResult Admin()
{
    if (HttpContext.Session.GetString("IsAdminLoggedIn") != "true")
    {
        return RedirectToAction("Login", "Admin");
    }

    return View(bookings);
}
    }
}
