using GooglePlaceDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Class
{
    public class SetAllCategories
    {
        public static List<string> FindAllCategories(List<Tuple<List<PlaceDetails>, string>> data)
        {
            List<string> categories = new List<string>();
            foreach (Tuple<List<PlaceDetails>, string> category in data)
            {
                categories.Add(category.Item2);
            }
            return categories;
        }
    }
}
