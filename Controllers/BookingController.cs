using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;

namespace CarCleanzApp.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View("Create");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking model)
        {
            if (ModelState.IsValid)
            {
                // You can save to DB here if needed
                // _context.Bookings.Add(model);
                // _context.SaveChanges();

                // Pass booking data to Success view using ViewBag
                ViewBag.Name = model.Name;
                ViewBag.Email = model.Email;
                ViewBag.VehicleType = model.VehicleType;
                ViewBag.ServicePackage = model.ServicePackage;
                ViewBag.BookingDate = model.BookingDate.ToString("dd-MM-yyyy");
                ViewBag.Phone = model.Phone;

                // Return the Success view directly with data
                return View("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}