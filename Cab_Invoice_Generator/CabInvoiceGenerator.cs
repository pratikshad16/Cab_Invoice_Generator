using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class CabInvoiceGenerator
    {
        private readonly double MINIMUM_COST_PER_KILOMETER_NORMAL = 10;
        private readonly int COST_PER_TIME_NORMAL = 1;
        private readonly double MINIMUM_FARE_NORMAL =  5;
        private readonly double MINIMUM_COST_PER_KILOMETER_PREMIUM = 15;
        private readonly int COST_PER_TIME_PREMIUM = 2;
        private readonly double MINIMUM_FARE_PREMIUM = 20;

        public double CalculateFare(string rideType,double distance, int time)
        {
           
            if (rideType == "normal")
            {
                double totalFare = distance * MINIMUM_COST_PER_KILOMETER_NORMAL + time * COST_PER_TIME_NORMAL;
                if (totalFare < MINIMUM_FARE_NORMAL)
                {
                    return MINIMUM_FARE_NORMAL;
                }
                return totalFare;
            }
            if (rideType == "premium")
            {
                double totalFare = (distance * MINIMUM_COST_PER_KILOMETER_PREMIUM + time * COST_PER_TIME_PREMIUM);
                if (totalFare > MINIMUM_FARE_PREMIUM)
                {
                    return totalFare;
                    
                }
            }
            return MINIMUM_FARE_PREMIUM;

        }

        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            int numberOfRides = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.rideType, ride.distance, ride.time);
                numberOfRides++;
            }
            InvoiceSummary invoiceSummery = new InvoiceSummary();
            invoiceSummery.numberOfRides = numberOfRides;
            invoiceSummery.totalFare = totalFare;
            invoiceSummery.CalulateAverageFare();
            return invoiceSummery;
        }
        
    }
    
}
