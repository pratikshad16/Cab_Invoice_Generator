using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
   public class RideRepository
    {
        Dictionary<string, List<Ride>> userRideObj = new Dictionary<string, List<Ride>>();
        public void AddRides(string userId, Ride[] rides)
        {
            bool checkRide = userRideObj.ContainsKey(userId);
            if (checkRide == false)
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                userRideObj.Add(userId, list);
            }
        }

        public Ride[] GetRides(string userId)
        {
            return userRideObj[userId].ToArray();
        }
    }
}

