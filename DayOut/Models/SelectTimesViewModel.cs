using GoogleCategories;
using GooglePlaceDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Models
{
    public class SelectTimesViewModel
    {
        public Customer Customer { get; set; }
        public List<List<PlaceDetails>> AllCategoriesWithPlaceDetails;
    }
}
