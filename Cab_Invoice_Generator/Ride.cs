using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
  public class Ride
    {
        public double distance;
        public  int time;
        public string rideType;

        public Ride(string rideType, double distance, int time)
        {
            this.rideType = rideType;
            this.distance = distance;
            this.time = time;
        }
    }
}
