using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class InvoiceSummary
    {
       
        public int numberOfRides { get; set; }
        public double totalFare { get; set; }
        public double averageFarePerRide { get; set; }
        public void CalulateAverageFare()
        {
            averageFarePerRide = totalFare / numberOfRides;
        }
    }
}
