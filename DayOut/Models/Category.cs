using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeToDo { get; set; }
        public int MiliSecondTime { get; set; }
        public bool IsAvailable { get; set; }
        public int? Cost { get; set; }

    }
}
