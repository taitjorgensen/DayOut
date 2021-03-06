﻿using GoogleCategories;
using GooglePlaceDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DayOut.Class
{
    public static class GetAllDetails
    {
        public static List<Tuple<List<PlaceDetails>, string>> ReplaceWithDetails(List<CategoryPlaces> allCategories)
        {
            List<Tuple<List<PlaceDetails>, string>> categoriesAndPlaces = new List<Tuple<List<PlaceDetails>, string>>();
            List<PlaceDetails> museums = new List<PlaceDetails>();
            List<PlaceDetails> movieTheaters = new List<PlaceDetails>();
            List<PlaceDetails> parks = new List<PlaceDetails>();
            List<PlaceDetails> restaurants = new List<PlaceDetails>();
            List<PlaceDetails> cafes = new List<PlaceDetails>();
            List<PlaceDetails> bowlingAlleys = new List<PlaceDetails>();
            List<PlaceDetails> iceCreamShops = new List<PlaceDetails>();
            List<PlaceDetails> miniGolfPlaces = new List<PlaceDetails>();
            List<PlaceDetails> shoppingMalls = new List<PlaceDetails>();
            foreach (CategoryPlaces category in allCategories)
            {
                if (category.name == "Museum")
                {
                    foreach (var place in category.Results)
                    {
                        string url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.PlaceId + "&category=basic,contact&key=" + APIKey.GoogleAPI;
                        museums.Add(GetObject.LocationDetails(url));
                    }
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(museums, "Museum");
                    categoriesAndPlaces.Add(final);
                }
                if (category.name == "Movie Theater")
                {
                    foreach (var place in category.Results)
                    {
                        string url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.PlaceId + "&category=basic,contact&key=" + APIKey.GoogleAPI;
                        movieTheaters.Add(GetObject.LocationDetails(url));
                    }
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(movieTheaters, "Movie Theater");
                    categoriesAndPlaces.Add(final);
                }
                if (category.name == "Park")
                {
                    foreach (var place in category.Results)
                    {
                        string url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.PlaceId + "&category=basic,contact&key=" + APIKey.GoogleAPI;
                        parks.Add(GetObject.LocationDetails(url));
                    }
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(parks, "Park");
                    categoriesAndPlaces.Add(final);
                }
                if (category.name == "Restaurant")
                {
                    foreach (var place in category.Results)
                    {
                        string url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.PlaceId + "&category=basic,contact&key=" + APIKey.GoogleAPI;
                        restaurants.Add(GetObject.LocationDetails(url));
                    }
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(restaurants, "Restaurant");
                    categoriesAndPlaces.Add(final);
                }
                if (category.name == "Cafe")
                {
                    foreach (var place in category.Results)
                    {
                        string url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.PlaceId + "&category=basic,contact&key=" + APIKey.GoogleAPI;
                        cafes.Add(GetObject.LocationDetails(url));
                    }
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(cafes, "Cafe");
                    categoriesAndPlaces.Add(final);
                }
                if (category.name == "Bowling Alley")
                {
                    foreach (var place in category.Results)
                    {
                        string url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.PlaceId + "&category=basic,contact&key=" + APIKey.GoogleAPI;
                        bowlingAlleys.Add(GetObject.LocationDetails(url));
                    }
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(bowlingAlleys, "Bowling Alley");
                    categoriesAndPlaces.Add(final);
                }
                if (category.name == "Ice Cream")
                {
                    foreach (var place in category.Results)
                    {
                        string url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.PlaceId + "&category=basic,contact&key=" + APIKey.GoogleAPI;
                        iceCreamShops.Add(GetObject.LocationDetails(url));
                    }
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(iceCreamShops, "Ice Cream");
                    categoriesAndPlaces.Add(final);
                }
                if (category.name == "Mini Golf")
                {
                    foreach (var place in category.Results)
                    {
                        string url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.PlaceId + "&category=basic,contact&key=" + APIKey.GoogleAPI;
                        miniGolfPlaces.Add(GetObject.LocationDetails(url));
                    }
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(miniGolfPlaces, "Mini Golf");
                    categoriesAndPlaces.Add(final);
                }
                if (category.name == "Shopping")
                {
                    foreach (var place in category.Results)
                    {
                        string url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.PlaceId + "&category=basic,contact&key=" + APIKey.GoogleAPI;
                        shoppingMalls.Add(GetObject.LocationDetails(url));
                    }
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(shoppingMalls, "Shopping");
                    categoriesAndPlaces.Add(final);
                }
            }

            return categoriesAndPlaces;
        }
    }
}