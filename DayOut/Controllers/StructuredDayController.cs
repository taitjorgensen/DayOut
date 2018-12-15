using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DayOut.Data;
using DayOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DayOut.Controllers
{
    public class StructuredDayController : Controller
    {
        public ApplicationDbContext db;
        public StructuredDayController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BuildDay(int? time = null)
        {
            ViewBag.Time = time;
            ViewData["Time"] = new SelectList(db.Times, "Id", "StandardTime");
            return View();
        }
        [HttpPost]
        public IActionResult BuildDay(BuildDayViewModel buildDay)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customerToUpdate = db.Customers.Where(c => c.UserId == userId).Single();
            if (customerToUpdate.StructStartTime == 0)
            {
                int startTime = db.Times.Where(t => t.Id == buildDay.NextTime).Select(t => t.MilitaryTime).Single();
                customerToUpdate.StructStartTime = startTime;
                db.SaveChanges();
            }
            if (buildDay.NextTime == null)
            {
                buildDay.NextTime = customerToUpdate.StructStartTime;
            }
            buildDay.TimeDisplay = db.Times.Where(t => t.Id == buildDay.NextTime).Select(t => t.StandardTime).Single();
            return RedirectToAction("BuildDay");
        }
    }
}