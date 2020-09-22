using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class CabInvoiceGenerator
    {
        private readonly double MINIMUM_COST_PER_KILOMETER = 10;
        private readonly int COST_PER_TIME = 1;
        private readonly double MINIMUM_FARE =  5;

        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * MINIMUM_COST_PER_KILOMETER + time * COST_PER_TIME;
            if (totalFare < MINIMUM_FARE)
            {
                return MINIMUM_FARE;
            }
            return totalFare;
        }

        public double CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
    }
    
}
