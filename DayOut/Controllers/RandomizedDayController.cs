using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DayOut.Controllers
{
    public class RandomizedDayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void SelectStartEndTime()
        {

        }
    }
}