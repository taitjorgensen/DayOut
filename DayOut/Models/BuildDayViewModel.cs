using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Models
{
    public class BuildDayViewModel
    {
        public Customer Customer { get; set; }
        public int? NextTime { get; set; }
        public string TimeDisplay { get; set; }
    }
}
