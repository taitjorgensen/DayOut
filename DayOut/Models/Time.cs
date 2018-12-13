using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Models
{
    public class Time
    {
        [Key]
        public int Id { get; set; }
        public string StandardTime { get; set; }
        public int MilitaryTime { get; set; }

    }
}
