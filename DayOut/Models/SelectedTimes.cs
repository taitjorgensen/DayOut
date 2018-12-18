using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Models
{
    public class SelectedTimes
    {
        [Key]
        public int Id { get; set; }
        public int Time { get; set; }
        public string TimeLabel { get; set; }
    }
}
