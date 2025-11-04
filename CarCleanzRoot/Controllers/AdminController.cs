using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CarCleanzApp.Controllers
{
    public class AdminController : Controller
    {
        private const string AdminUsername = "admin";
        private const string AdminPassword = "carcleanz@123"; // you can change this

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == AdminUsername && password == AdminPassword)
            {
                HttpContext.Session.SetString("IsAdminLoggedIn", "true");
                return RedirectToAction("Admin", "Booking");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdminLoggedIn");
            return RedirectToAction("Login");
        }
    }
}
