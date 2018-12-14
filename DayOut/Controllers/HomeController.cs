using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DayOut.Models;
using DayOut.Data;
using System.Security.Claims;
using DayOut.Class;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DayOut.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChooseDayType()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetStartAddress(bool isValidAddress = true)
        {
            try
            {
                ViewBag.isValid = isValidAddress;
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
                ViewData["StateId"] = new SelectList(db.States, "Id", "Name");
                List<double> radii = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 20, 25, 30, 40, 50, 60, 70, 80, 90, 100};
                ViewData["Radii"] = new SelectList(radii);
                return View(customer);
            }
            catch
            {
                return RedirectToAction("Login", "Identity/Account");
            }

        }
        [HttpPost]
        public IActionResult SetStartAddress(Customer customer)
        {
            string state = db.States.Where(s => s.Id == customer.StateId).Select(s => s.Name).Single();
            if (Geocode.GetLongLat(customer, state))
            {
                if (Geocode.isValidLocation)
                {
                    customer.Latitude = Geocode.latitude;
                    customer.Longitude = Geocode.longtitude;
                }
                else
                {
                    return RedirectToAction("SetStartAddress", new {isValidAddress = false });
                }
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customerToUpdate = db.Customers.Where(c => c.UserId == userId).Single();
            customerToUpdate.Longitude = customer.Longitude;
            customerToUpdate.Latitude = customer.Latitude;
            customerToUpdate.Radius = customer.Radius;
            db.SaveChanges();
            return RedirectToAction("ChooseDayType");
        }

    }
}
