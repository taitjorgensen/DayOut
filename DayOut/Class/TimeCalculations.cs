using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayOut.Class
{
    public static class TimeCalculations
    {
        
        public static int FindTimeSpan(int EarlierTime, int LaterTime)
        {
            if (EarlierTime == 2400)
            {
                EarlierTime = 0;
            }
            int hours = LaterTime - EarlierTime;
            string stringHours = hours.ToString();
            if (stringHours.EndsWith("30") || stringHours.EndsWith("70"))
            {
                List<char> timeBrokenUp = stringHours.ToList();
                List<string> timeBrokenIntoString = new List<string>();
                foreach (char num in timeBrokenUp)
                {
                    timeBrokenIntoString.Add(num.ToString());
                }
                timeBrokenIntoString[timeBrokenIntoString.Count - 2] = "5";
                string stringHoursConverted = "";
                foreach (string num in timeBrokenIntoString)
                {
                    stringHoursConverted += num;
                }
                hours = Convert.ToInt32(stringHoursConverted);

            }
            return hours;
        }
    }
}
