using GooglePlaceDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Models
{
    public class SelectCategoriesViewModel
    {
        public Customer Customer { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Selected { get; set; }
    }
}
