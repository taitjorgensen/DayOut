using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DayOut.Class
{
    public static class RandomInstance
    {
        public static Random randomSimple = new Random();

        //Function to get a random number 
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        private static readonly ThreadLocal<Random> appRandom
     = new ThreadLocal<Random>(() => new Random());
    }
}
