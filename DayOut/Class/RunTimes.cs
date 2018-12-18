using DayOut.Data;
using DayOut.Models;
using DayOut.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Class
{
    public class RunTimes
    {
        public ApplicationDbContext db;
        public Customer customer = new Customer();
        public List<int> hardTimes = new List<int>();
        public List<Place> hardPlaces = new List<Place>();
        Place hardPlace1 = new Place();
        Place hardPlace2 = new Place();
        public RunTimes(ApplicationDbContext context, Customer customer)
        {
            hardPlace1.Name = "Federal Prison";
            hardPlace1.Category = "Hell";
            hardPlace2.Name = "Hell";
            hardPlace2.Category = "Hell";
            hardPlaces.Add(hardPlace1);
            hardPlaces.Add(hardPlace2);
            hardTimes = new List<int>() { 1118};
            db = context;
            this.customer = customer;
        }
        public Task SendIf(List<Place> places = null)
        {
            bool done = false;
            bool sentFirst = false;
            int j = 0;
            if (places == null)
            {
                places = hardPlaces;
            }
            while(done == false)
            {
                DateTime currentTime = DateTime.Now;
                string militaryTime = currentTime.ToString("HHmm");
                int currentMilTime = Convert.ToInt32(militaryTime);
                if (sentFirst == false)
                {
                    SMS.SendStartDayOutMessage(customer, places[0]);
                    sentFirst = true;
                }
                if (currentMilTime > customer.RandStartTime)
                {
                    if (j > 0)
                    {
                        for (int i = 1; i < places.Count; i++)
                        {
                            SMS.SendNextStopMessage(customer, places[i]);
                            System.Threading.Thread.Sleep(120000);
                        }
                        done = true;
                    }
                }
                j++;
                System.Threading.Thread.Sleep(120000);
            }
            return null;
        }
    }
}
