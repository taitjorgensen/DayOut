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
        public static List<CategoryPlaces> CategoriesAvailable(Customer customer, List<string> filteredRequest = null)
        {
            int radius = Convert.ToInt32(customer.Radius * 1609);
            string beginingUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + customer.Latitude.ToString() + "," + customer.Longitude.ToString() + "&radius=" + radius;
            CategoryPlaces googleMuseums = null;
            CategoryPlaces googleMovieTheater = null;
            CategoryPlaces googlePark = null;
            CategoryPlaces googleRestaurant = null;
            CategoryPlaces googleCafe = null;
            CategoryPlaces googleBowlingAlley = null;
            CategoryPlaces googleIceCream = null;
            CategoryPlaces googleMiniGolf = null;
            CategoryPlaces googleShopping = null;
            if (filteredRequest == null)
            {
                googleMuseums = GetObject.ListOfLocations(beginingUrl + "&type=museum&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                googleMovieTheater = GetObject.ListOfLocations(beginingUrl + "&type=movie_theater&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                googlePark = GetObject.ListOfLocations(beginingUrl + "&type=park&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                googleRestaurant = GetObject.ListOfLocations(beginingUrl + "&type=restaurant&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                googleCafe = GetObject.ListOfLocations(beginingUrl + "&type=cafe&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                googleBowlingAlley = GetObject.ListOfLocations(beginingUrl + "&type=bowling_alley&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                googleIceCream = GetObject.ListOfLocations(beginingUrl + "&type=food+store&keyword=ice+cream&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                googleMiniGolf = GetObject.ListOfLocations(beginingUrl + "&type=point_of_interest&keyword=mini+golf&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                googleShopping = GetObject.ListOfLocations(beginingUrl + "&type=shopping_mall&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
            }
            else
            {
                foreach (string name in filteredRequest)
                {
                    switch (name)
                    {
                        case "Museum":
                            googleMuseums = GetObject.ListOfLocations(beginingUrl + "&type=museum&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                            break;
                        case "Movie Theater":
                            googleMovieTheater = GetObject.ListOfLocations(beginingUrl + "&type=movie_theater&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                            break;
                        case "Park":
                            googlePark = GetObject.ListOfLocations(beginingUrl + "&type=park&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                            break;
                        case "Restaurant":
                            googleRestaurant = GetObject.ListOfLocations(beginingUrl + "&type=restaurant&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                            break;
                        case "Cafe":
                            googleCafe = GetObject.ListOfLocations(beginingUrl + "&type=cafe&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                            break;
                        case "Bowling Alley":
                            googleBowlingAlley = GetObject.ListOfLocations(beginingUrl + "&type=bowling_alley&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                            break;
                        case "Ice Cream":
                            googleIceCream = GetObject.ListOfLocations(beginingUrl + "&type=food+store&keyword=ice+cream&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                            break;
                        case "Mini Golf":
                            googleMiniGolf = GetObject.ListOfLocations(beginingUrl + "&type=point_of_interest&keyword=mini+golf&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                            break;
                        case "Shopping":
                            googleShopping = GetObject.ListOfLocations(beginingUrl + "&type=shopping_mall&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s");
                            break;
                        default:
                            break;
                    }
                }
            }


            List<CategoryPlaces> categories = new List<CategoryPlaces>();
            if (googleMuseums != null)
            {
                if (googleMuseums.Status == "OK")
                {
                    googleMuseums.name = "Museum";
                    categories.Add(googleMuseums);
                }
            }

            if (googleMovieTheater != null)
            {
                if (googleMovieTheater.Status == "OK")
                {
                    googleMovieTheater.name = "Movie Theater";
                    categories.Add(googleMovieTheater);
                }
            }

            if (googlePark != null)
            {
                if (googlePark.Status == "OK")
                {
                    googlePark.name = "Park";
                    categories.Add(googlePark);
                }
            }
            if (googleRestaurant != null)
            {
                if (googleRestaurant.Status == "OK")
                {
                    googleRestaurant.name = "Restaurant";
                    categories.Add(googleRestaurant);
                }
            }
            if (googleCafe != null)
            {
                if (googleCafe.Status == "OK")
                {
                    googleCafe.name = "Cafe";
                    categories.Add(googleCafe);
                }
            }
            if (googleBowlingAlley != null)
            {
                if (googleBowlingAlley.Status == "OK")
                {
                    googleBowlingAlley.name = "Bowling Alley";
                    categories.Add(googleBowlingAlley);
                }
            }
            if (googleIceCream != null)
            {
                if (googleIceCream.Status == "OK")
                {
                    googleIceCream.name = "Ice Cream";
                    categories.Add(googleIceCream);
                }
            }
            if (googleMiniGolf != null)
            {
                if (googleMiniGolf.Status == "OK")
                {
                    googleMiniGolf.name = "Mini Golf";
                    categories.Add(googleMiniGolf);
                }
            }
            if (googleShopping != null)
            {
                if (googleShopping.Status == "OK")
                {
                    googleShopping.name = "Shopping";
                    categories.Add(googleShopping);
                }
            }
            return categories;
        }
    }
}
