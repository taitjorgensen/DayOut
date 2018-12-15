using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DayOut.Class;
using DayOut.Data;
using DayOut.Data.Migrations;
using DayOut.Models;
using GoogleCategories;
using GooglePlaceDetails;
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
            return RedirectToAction("SelectStartEndTime");
        }

        public IActionResult SelectStartEndTime()
        {
            ViewData["Time"] = new SelectList(db.Times, "Id", "StandardTime");
            return View();
        }
        [HttpPost]
        public IActionResult SelectStartEndTime(SelectTimesViewModel selectTimesViewModel)
        {
            int startTime = db.Times.Where(t => t.Id == selectTimesViewModel.Customer.RandStartTime).Select(t => t.MilitaryTime).Single();
            int endTime = db.Times.Where(t => t.Id == selectTimesViewModel.Customer.RandEndTime).Select(t => t.MilitaryTime).Single();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customerToUpdate = db.Customers.Where(c => c.UserId == userId).Single();
            customerToUpdate.RandEndTime = endTime;
            customerToUpdate.RandStartTime = startTime;
            customerToUpdate.TimeLeft = TimeCalculations.FindTimeSpan(startTime, endTime);
            db.SaveChanges();

            Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
            List<CategoryPlaces> availableCategories = GetCategoriesAvailable.CategoriesAvailable(customer);
            List<Tuple<List<PlaceDetails>, string>> data = GetAllDetails.ReplaceWithDetails(availableCategories);
            List<Tuple<List<PlaceDetails>, string>> finalData = FilterPlacesOpen.ReturnFilteredPlaces(data, customer.RandStartTime, customer.RandEndTime);
            List<string> categories = SetAllCategories.FindAllCategories(finalData);

            SelectCategoriesViewModel selectCategoriesViewModel = new SelectCategoriesViewModel() { Customer = customer, Categories = categories};

            // Pass to SelectCategoriesViewModel view
            return RedirectToAction("SelectCategories", selectCategoriesViewModel);
        }

        //GET
        public IActionResult SelectCategories(SelectCategoriesViewModel selectCategoriesViewModel, string selected = "")
        {
            if (selected != "")
            {
                selectCategoriesViewModel.Selected.Add(selected);
            }
            return View(selectCategoriesViewModel);
        }
        [HttpPost]
        public IActionResult SelectCategories(SelectCategoriesViewModel selectCategoriesViewModel, string selected = "", bool complete = false)
        {
            if (selected != "")
            {
                selectCategoriesViewModel.Selected.Add(selected);
            }
            if (complete == true)
            {

            }
            else
            {

            }
            return View(selectCategoriesViewModel);
        }
    }

}

