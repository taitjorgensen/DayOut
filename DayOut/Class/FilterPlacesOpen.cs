using GoogleCategories;
using GooglePlaceDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Class
{
    public static class FilterPlacesOpen
    {
        public static List<Tuple<List<PlaceDetails>, string>> ReturnFilteredPlaces(List<Tuple<List<PlaceDetails>, string>> allCategories, int startTime, int endTime = -1)
        {

            List<Tuple<List<PlaceDetails>, string>> categoriesAndPlaces = new List<Tuple<List<PlaceDetails>, string>>();

            int day = (int)System.DateTime.Now.DayOfWeek;


            foreach (Tuple<List<PlaceDetails>, string> category in allCategories)
            {
                List<PlaceDetails> categoryBuild = new List<PlaceDetails>();

                for (int i = 0; i < category.Item1.Count; i++)
                {
                    if (category.Item2 != "parks")
                    {
                        try
                        {
                            if (category.Item1[i].Result.OpeningHours.Periods[day].Close.Time > endTime && category.Item1[i].Result.OpeningHours.Periods[day].Open.Time < startTime)
                            {
                                categoryBuild.Add(category.Item1[i]);
                            }
                        }
                        catch
                        {

                        }
                    }else if (startTime > 700 && endTime < 1800)
                    {
                        categoryBuild.Add(category.Item1[i]);
                    }
                }
                if (categoryBuild.Count > 0)
                {
                    Tuple<List<PlaceDetails>, string> final = new Tuple<List<PlaceDetails>, string>(categoryBuild, category.Item2);
                    categoriesAndPlaces.Add(final);
                }
            }
            return categoriesAndPlaces;
        }
    }
}
