using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DayOut.Class;
using DayOut.Data;
using DayOut.Data.Migrations;
using DayOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DayOut.Controllers
{
    public class RandomizedDayController : Controller
    {
        public ApplicationDbContext db;

        //private readonly ApplicationDbContext _context;


        public RandomizedDayController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectStartEndTime()
        {
            ViewData["Time"] = new SelectList(db.Times, "Id", "StandardTime");
            return View();
        }
        [HttpPost]
        public IActionResult SelectStartEndTime([Bind("Id, RandEndTime, RandStartTime")] Customer customer)
        {
            int startTime = db.Times.Where(t => t.Id == customer.RandStartTime).Select(t => t.MilitaryTime).Single();
            int endTime = db.Times.Where(t => t.Id == customer.RandEndTime).Select(t => t.MilitaryTime).Single();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customerToUpdate = db.Customers.Where(c => c.UserId == userId).Single();
            customerToUpdate.RandEndTime = endTime;
            customerToUpdate.RandStartTime = startTime;
            customerToUpdate.TimeLeft = TimeCalculations.FindTimeSpan(startTime, endTime);
            db.SaveChanges();
            return View();
        }
    }
}