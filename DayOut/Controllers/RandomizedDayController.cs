using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DayOut.Class;
using DayOut.Data;
using DayOut.Data.Migrations;
using DayOut.Models;
using GoogleCategories;
using GooglePlaceDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            Customer customer = new Customer() { RandStartTime = 0800, RandEndTime = 1300 };
            SelectTimesViewModel selectTimesViewModel = new SelectTimesViewModel() { Customer = customer };
            DateTime currentTime = DateTime.Now;
            string militaryTime = currentTime.ToString("HHmm");
            int currentMilTime = Convert.ToInt32(militaryTime);
            ViewData["Time"] = new SelectList(db.Times.Where(t => t.MilitaryTime > currentMilTime), "Id", "StandardTime");
            return View(selectTimesViewModel);
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
            return RedirectToAction("RetrieveData");
        }

        public IActionResult RetrieveData(int endGoTo = 0)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
            List<CategoryPlaces> availableCategories = GetCategoriesAvailable.CategoriesAvailable(customer);
            List<Tuple<List<PlaceDetails>, string>> data = GetAllDetails.ReplaceWithDetails(availableCategories);
            List<Tuple<List<PlaceDetails>, string>> finalData = FilterPlacesOpen.ReturnFilteredPlaces(data, customer.RandStartTime, customer.RandEndTime);
            List<string> categories = SetAllCategories.FindAllCategories(finalData);
            SetCategoriesTable(categories);
            TruncateSelectedTable();
            if (endGoTo == 0)
            {
                return RedirectToAction("SelectCategories");
            }
            else
            {
                //Redirect to show route
                return RedirectToAction("SelectCategories");
            }
        }
        private void TruncateSelectedTable()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [SelectedCategories]");
        }
        private void TruncatePlacesTable()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
            List<Place> customerPlaces = db.Places.Where(p => p.CustomerId == customer.Id).ToList();
            foreach (Place place in customerPlaces)
            {
                db.Places.Remove(place);
                db.SaveChanges();
            }
        }

        private void SetCategoriesTable(List<string> availableCategories)
        {
            List<Category> allCategories = db.Categories.ToList();
            bool fired = false;
            foreach (Category category in allCategories)
            {
                foreach (string name in availableCategories)
                {
                    if (category.Name == name)
                    {
                        category.IsAvailable = true;
                        db.SaveChanges();
                        fired = true;
                        break;
                    }
                }
                if (fired != true)
                {
                    category.IsAvailable = false;
                    db.SaveChanges();
                }
                fired = false;
            }
        }

        //GET
        public IActionResult SelectCategories(string selected = "")
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
            if (selected != "")
            {
                SelectedCategory selectedCategory = new SelectedCategory() { Name = selected };
                db.SelectedCategories.Add(selectedCategory);
                Category category = db.Categories.Where(c => c.Name == selected).Single();
                category.IsAvailable = false;
                customer.TimeLeft -= category.TimeToDo;
                db.SaveChanges();
            }
            SelectCategoriesViewModel selectCategoriesViewModel = new SelectCategoriesViewModel();
            selectCategoriesViewModel.Categories = db.Categories.Where(c => c.IsAvailable == true && c.TimeToDo <= customer.TimeLeft).Select(c => c.Name).ToList();
            selectCategoriesViewModel.Selected = db.SelectedCategories.Select(c => c.Name).ToList();
            ViewBag.TimeLeft = customer.TimeLeft < 50 ? false : true;
            ViewBag.OptionsLeft = selectCategoriesViewModel.Categories.Count > 0 ? true : false;
            ViewBag.HasSelected = selectCategoriesViewModel.Selected.Count > 0 ? true : false;
            return View(selectCategoriesViewModel);
        }
        public IActionResult BuildRoute()
        {
            SetPlaces();

            return RedirectToAction("DisplayRoute");
        }

        private void SetPlaces()
        {
            List<string> selectedCategories = db.SelectedCategories.Select(c => c.Name).ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
            List<CategoryPlaces> availableCategories = GetCategoriesAvailable.CategoriesAvailable(customer, selectedCategories);
            List<Tuple<List<PlaceDetails>, string>> data = GetAllDetails.ReplaceWithDetails(availableCategories);
            List<Tuple<List<PlaceDetails>, string>> finalData = FilterPlacesOpen.ReturnFilteredPlaces(data, customer.RandStartTime, customer.RandEndTime);
            TruncatePlacesTable();
            Random random = new Random();
            foreach (Tuple<List<PlaceDetails>, string> category in finalData)
            {
                PlaceDetails place = category.Item1[random.Next(0, category.Item1.Count - 1)];
                Place newPlace = new Place()
                {
                    Name = place.Result.Name,
                    PriceLevel = 0,
                    Category = category.Item2,
                    Latitude = place.Result.Geometry.Location.Lat,
                    Longitude = place.Result.Geometry.Location.Lng,
                    PlaceId = place.Result.PlaceId,
                    CustomerId = customer.Id
                };
                string error = "Not Provided";
                try
                {
                    newPlace.PhoneNumber = place.Result.FormattedPhoneNumber;
                }
                catch
                {
                    newPlace.PhoneNumber = error;
                }
                try
                {
                    newPlace.Address = place.Result.FormattedAddress;
                }
                catch
                {
                    newPlace.Address = error;
                }
                try
                {
                    newPlace.Rating = place.Result.Rating;
                }
                catch
                {
                    newPlace.Rating = 0;
                }
                db.Places.Add(newPlace);
                db.SaveChanges();
            }
        }

        public IActionResult DisplayRoute(bool fromSelect = true)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
            if (fromSelect == false)
            {
                if (customer.HasRoute == false)
                {
                    return RedirectToAction("Index", "Home", new { hasroute = false });
                }
            }
            DisplayRouteViewModel displayRoute = new DisplayRouteViewModel();
            displayRoute.Places = db.Places.Where(p => p.CustomerId == customer.Id).ToList();
            displayRoute.Addresses = new List<string>();
            foreach (Place place in displayRoute.Places)
            {
                displayRoute.Addresses.Add(place.Address);
            }
            displayRoute.PlaceLetters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            Thread doThis = new Thread(delegate ()
            {
                RunTimes runTimes = new RunTimes(db, customer);
                runTimes.SendIf(displayRoute.Places);
            });
            doThis.Start();
            customer.HasRoute = true;
            db.SaveChanges();
            return View(displayRoute);
        }

        public IActionResult Surprise(bool fromSelect = true)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
            if (fromSelect == false)
            {
                if (customer.HasRoute == false)
                {
                    return RedirectToAction("Index", "Home", new { hasroute = false });
                }
            }
            DisplayRouteViewModel displayRoute = new DisplayRouteViewModel();
            displayRoute.Places = db.Places.Where(p => p.CustomerId == customer.Id).ToList();
            displayRoute.Addresses = new List<string>();
            foreach (Place place in displayRoute.Places)
            {
                displayRoute.Addresses.Add(place.Address);
            }
            displayRoute.PlaceLetters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            Thread doThis = new Thread(delegate ()
            {
                RunTimes runTimes = new RunTimes(db, customer);
                runTimes.SendIf(displayRoute.Places);
            });
            doThis.Start();
            customer.HasRoute = true;
            db.SaveChanges();
            return View(displayRoute);
        }
        public IActionResult LoadingGif()
        {
            return PartialView();
        }
        public IActionResult SelectModeType()
        {
            return PartialView();
        }
    }

}

