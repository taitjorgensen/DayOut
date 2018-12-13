using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }
        public int ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int RandStartTime { get; set; }
        public int RandEndTime { get; set; }
        public int StructStartTime { get; set; }
        public int StructEndTime { get; set; }
        public int TimeLeft { get; set; }
        public DateTime MemberSince { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set;}

    }
}
