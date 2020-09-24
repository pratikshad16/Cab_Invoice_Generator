//-----------------------------------------------------------------------
// <copyright file="CabInvoiceGenerator.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cab_Invoice_Generator
{
    /// <summary>
    /// Main Class
    /// </summary>
    public class CabInvoiceGenerator
    {
        /// <summary>
        /// minimum cost per kilometer normal
        /// </summary>
        private readonly double minimumCostPerKilometerNormal = 10;

        /// <summary>
        /// cost per time normal
        /// </summary>
        private readonly int costPerTimeNormal = 1;

        /// <summary>
        /// minimum fare normal
        /// </summary>
        private readonly double minimumFareNormal = 5;

        /// <summary>
        /// minimum cost per kilometer premium
        /// </summary>
        private readonly double minimumCostPerKilometerPremium = 15;

        /// <summary>
        /// cost per time premium
        /// </summary>
        private readonly int costPerTimePremium = 2;

        /// <summary>
        /// minimum fare premium
        /// </summary>
        private readonly double minimumFarePremium = 20;

        /// <summary>
        /// method to calculate total fare
        /// </summary>
        /// <param name="rideType">ride type.</param>
        /// <param name="distance">total distance.</param>
        /// <param name="time">total time.</param>
        /// <returns>return total fare</returns>
        public double CalculateFare(string rideType, double distance, int time)
        {
            if (rideType == "normal")
            {
                double totalFare = (distance * this.minimumCostPerKilometerNormal) + (time * this.costPerTimeNormal);
                if (totalFare < this.minimumFareNormal)
                {
                    return this.minimumFareNormal;
                }

                return totalFare;
            }

            if (rideType == "premium")
            {
                double totalFare = (distance * this.minimumCostPerKilometerPremium) + (time * this.costPerTimePremium);
                if (totalFare > this.minimumFarePremium)
                {
                    return totalFare;
                }
            }

            return this.minimumFarePremium;
        }

        /// <summary>
        /// to calculate multiple ride
        /// </summary>
        /// <param name="rides">to get rides.</param>
        /// <returns>multiple rides summary.</returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            int numberOfRides = 0;
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.RideType, ride.Distance, ride.Time);
                numberOfRides++;
            }

            InvoiceSummary invoiceSummery = new InvoiceSummary();
            invoiceSummery.NumberOfRides = numberOfRides;
            invoiceSummery.TotalFare = totalFare;
            invoiceSummery.CalulateAverageFare();
            return invoiceSummery;
        }
    }
}
