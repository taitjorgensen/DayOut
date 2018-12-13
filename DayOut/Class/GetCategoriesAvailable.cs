using DayOut.Models;
using GoogleCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Class
{
    public static class GetCategoriesAvailable
    {
        public static List<CategoryPlaces> CategoriesAvailable(Customer customer)
        {
            int radius = Convert.ToInt32(customer.Radius * 1609);
            string beginingUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + customer.Latitude.ToString() + "," + customer.Longitude.ToString() + "&radius=" + radius;
            CategoryPlaces googleMuseums = GetObject.ListOfLocations(beginingUrl + "&type=museum&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
            CategoryPlaces googleMovieTheater = GetObject.ListOfLocations(beginingUrl + "&type=movie_theater&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
            CategoryPlaces googlePark = GetObject.ListOfLocations(beginingUrl + "&type=park&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
            CategoryPlaces googleRestaurant = GetObject.ListOfLocations(beginingUrl + "&type=restaurant&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
            CategoryPlaces googleCafe = GetObject.ListOfLocations(beginingUrl + "&type=cafe&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
            CategoryPlaces googleBowlingAlley = GetObject.ListOfLocations(beginingUrl + "&type=bowling_alley&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
            CategoryPlaces googleIceCream = GetObject.ListOfLocations(beginingUrl + "&type=food+store&keyword=ice+cream&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
            CategoryPlaces googleMiniGolf = GetObject.ListOfLocations(beginingUrl + "&type=point_of_interest&keyword=mini+golf&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
            CategoryPlaces googleShopping = GetObject.ListOfLocations(beginingUrl + "&type=shopping_mall&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");

            List<CategoryPlaces> categories = new List<CategoryPlaces>();
            if (googleMuseums.Status == "OK")
            {
                googleMuseums.name = "Museum";
                categories.Add(googleMuseums);
            }
            if (googleMovieTheater.Status == "OK")
            {
                googleMovieTheater.name = "Movie Theater";
                categories.Add(googleMovieTheater);
            }
            if (googlePark.Status == "OK")
            {
                googlePark.name = "Park";
                categories.Add(googlePark);
            }
            if (googleRestaurant.Status == "OK")
            {
                googleRestaurant.name = "Restaurant";
                categories.Add(googleRestaurant);
            }
            if (googleCafe.Status == "OK")
            {
                googleCafe.name = "Cafe";
                categories.Add(googleCafe);
            }
            if (googleBowlingAlley.Status == "OK")
            {
                googleBowlingAlley.name = "Bowling Alley";
                categories.Add(googleBowlingAlley);
            }
            if (googleIceCream.Status == "OK")
            {
                googleIceCream.name = "Ice Cream";
                categories.Add(googleIceCream);
            }
            if (googleMiniGolf.Status == "OK")
            {
                googleMiniGolf.name = "Mini Golf";
                categories.Add(googleMiniGolf);
            }
            if (googleShopping.Status == "OK")
            {
                googleShopping.name = "Shopping";
                categories.Add(googleShopping);
            }

            return categories;
        }
    }
}
