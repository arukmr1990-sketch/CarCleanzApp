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
                _context.Bookings.Add(model);
                _context.SaveChanges();

                ViewBag.Name = model.Name;
                ViewBag.Email = model.Email;
                ViewBag.VehicleType = model.VehicleType;
                ViewBag.ServicePackage = model.ServicePackage;
                ViewBag.BookingDate = model.BookingDate.ToString("dd-MM-yyyy");
                ViewBag.Phone = model.Phone;

                return View("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Admin()
        {
            // ? Fetch all bookings from SQLite
            var bookings = _context.Bookings.ToList();
            return View(bookings);
        }
    }
}