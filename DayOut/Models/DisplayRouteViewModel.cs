using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Models
{
    public class DisplayRouteViewModel
    {
        public List<Place> Places { get; set; }
        public List<string> Addresses { get; set; }

        public List<string> PlaceLetters { get; set; }
    }
}
