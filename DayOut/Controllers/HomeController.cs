using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DayOut.Models;

namespace DayOut.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DateTime CurrentDateTime = DateTime.Now;
            var TimeOnly = CurrentDateTime.TimeOfDay;
            DateTime FutureTime = new DateTime(1,1,1,14,30,00);
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
    }
}
