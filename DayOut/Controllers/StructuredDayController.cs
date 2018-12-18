using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DayOut.Class;
using DayOut.Data;
using DayOut.Models;
using GoogleCategories;
using GooglePlaceDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult BuildDay()
        {
            DateTime currentTime = DateTime.Now;
            string militaryTime = currentTime.ToString("HHmm");
            int currentMilTime = Convert.ToInt32(militaryTime);
            ViewData["Time"] = new SelectList(db.Times, "Id", "StandardTime");
            //ViewData["Time"] = new SelectList(db.Times.Where(t => t.MilitaryTime > currentMilTime - 50), "Id", "StandardTime");
            return View();
        }
        [HttpPost]
        public IActionResult BuildDay(Customer customer)
        {
            int startTime = db.Times.Where(t => t.Id == customer.StructStartTime).Select(t => t.MilitaryTime).Single();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customerToUpdate = db.Customers.Where(c => c.UserId == userId).Single();
            customerToUpdate.StructStartTime = startTime;
            db.SaveChanges();
            TruncateSelectedTable();
            TruncateSelectedTimesTable();
            return RedirectToAction("SelectCategoriesStructured");
        }
        private void TruncateSelectedTable()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [SelectedCategories]");
        }
        private void TruncateSelectedTimesTable()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [SelectedTimes]");
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
        public IActionResult SelectCategoriesStructured(string selected = "")
        {
            
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
            int nextTime = customer.StructStartTime;
            SelectCategoriesViewModel selectCategoriesViewModel = new SelectCategoriesViewModel();
            selectCategoriesViewModel.PlaceTime = db.SelectedTimes.Select(t => t.TimeLabel).ToList();
            if (selectCategoriesViewModel.PlaceTime.Count == 0)
            {
                SelectedTimes selectedTime = new SelectedTimes();
                selectedTime.Time = db.Times.Where(t => t.MilitaryTime == customer.StructStartTime).Select(t => t.MilitaryTime).Single();
                selectedTime.TimeLabel = db.Times.Where(t => t.MilitaryTime == customer.StructStartTime).Select(t => t.StandardTime).Single();
                db.SelectedTimes.Add(selectedTime);
                db.SaveChanges();
            }
            int maxId = db.SelectedTimes.Max(t => t.Id); //Get max Id in selected times
            int lastTime = db.SelectedTimes.Where(t => t.Id == maxId).Select(t => t.Time).Single(); // Use max Id to get string of last time
            if (selected != "")
            {
                Category category = db.Categories.Where(c => c.Name == selected).Single();
                SelectedTimes selectedTime = new SelectedTimes();
                int currentId = db.Times.Where(t => t.MilitaryTime == lastTime).Select(t => t.Id).Single(); // Get the current Id of Times table where time name matches last time
                int nextTimeId = currentId + category.IncramentAmount;
                nextTimeId = nextTimeId > 48 ? (nextTimeId - 48) : nextTimeId;
                selectedTime.Time = db.Times.Where(t => t.Id == nextTimeId).Select(t => t.MilitaryTime).Single();
                nextTime = db.Times.Where(t => t.Id == nextTimeId).Select(t => t.MilitaryTime).Single();
                selectedTime.TimeLabel = db.Times.Where(t => t.Id == nextTimeId).Select(t => t.StandardTime).Single();// Set new time to add equal to the time after category completion
                db.SelectedTimes.Add(selectedTime);
                db.SaveChanges();
            }
            List<CategoryPlaces> availableCategories = GetCategoriesAvailable.CategoriesAvailable(customer);
            List<Tuple<List<PlaceDetails>, string>> data = GetAllDetails.ReplaceWithDetails(availableCategories);
            List<Tuple<List<PlaceDetails>, string>> finalData = FilterPlacesOpen.ReturnFilteredPlaces(data, nextTime, nextTime + 300);
            List<string> categories = SetAllCategories.FindAllCategories(finalData);
            SetCategoriesTable(categories);
            if (selected != "")
            {
                SelectedCategory selectedCategory = new SelectedCategory() { Name = selected };
                db.SelectedCategories.Add(selectedCategory);
                Category category = db.Categories.Where(c => c.Name == selected).Single();
                if (category.Name != "Restaurant")
                {
                    category.IsAvailable = false;
                }
                db.SaveChanges();
            }
            selectCategoriesViewModel.PlaceTime = db.SelectedTimes.Select(t => t.TimeLabel).ToList();
            selectCategoriesViewModel.Categories = db.Categories.Where(c => c.IsAvailable == true).Select(c => c.Name).ToList();
            selectCategoriesViewModel.Selected = db.SelectedCategories.Select(c => c.Name).ToList();
            ViewBag.OptionsLeft = selectCategoriesViewModel.Categories.Count > 0 ? true : false;
            ViewBag.HasSelected = selectCategoriesViewModel.Selected.Count > 0 ? true : false;
            return View(selectCategoriesViewModel);
        }

        public IActionResult DisplayRoute(bool fromSelect = true)
        {
            SetPlaces();
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
            displayRoute.GoogleAPI = APIKey.GoogleAPI;
            displayRoute.Times = db.SelectedTimes.Select(t => t.TimeLabel).ToList();
            displayRoute.Times.Add("End");
            foreach (Place place in displayRoute.Places)
            {
                displayRoute.Addresses.Add(place.Address);
            }
            displayRoute.PlaceLetters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
            customer.HasRoute = true;
            db.SaveChanges();
            return View(displayRoute);
        }

        private void SetPlaces()
        {
            TruncatePlacesTable();
            List<string> selectedCategories = db.SelectedCategories.Select(c => c.Name).ToList();
            List<int> times = db.SelectedTimes.Select(t => t.Time).ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = db.Customers.Where(c => c.UserId == userId).Single();
            for (int i = 0; i < selectedCategories.Count; i++)
            {
                List<string> catName = new List<string>();
                catName.Add(selectedCategories[i]);
                List<CategoryPlaces> availableCategories = GetCategoriesAvailable.CategoriesAvailable(customer, catName);
                List<Tuple<List<PlaceDetails>, string>> data = GetAllDetails.ReplaceWithDetails(availableCategories);
                List<Tuple<List<PlaceDetails>, string>> finalData = FilterPlacesOpen.ReturnFilteredPlaces(data, times[i], times[i] + 300);
                CheckForPlace(finalData, customer);
            }
        }

        public bool CheckForPlace(List<Tuple<List<PlaceDetails>, string>> finalData, Customer customer)
        {
            foreach (Tuple<List<PlaceDetails>, string> category in finalData)
            {
                List<Place> allPlacesSet = db.Places.ToList();
                //int randomNum = RandomInstance.randomSimple.Next(0, category.Item1.Count - 1);
                int randomNum = RandomInstance.RandomNumber(0, category.Item1.Count);
                PlaceDetails place = category.Item1[randomNum];
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
                //foreach (Place placeIteration in allPlacesSet)
                //{
                //    if (placeIteration.Name == newPlace.Name && category.Item1.Count > 1)
                //    {
                //        System.Threading.Thread.Sleep(3000);
                //        return CheckForPlace(finalData, customer);
                //    }
                //}
                db.Places.Add(newPlace);
                db.SaveChanges();
            }
            return true;
        }
        public IActionResult LoadingGif()
        {
            return PartialView();
        }
    }
}