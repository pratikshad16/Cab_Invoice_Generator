namespace Cab_Invoice_Generator
{
    /// <summary>
    /// Invoice summary Class
    /// </summary>
    public class InvoiceSummary
    {
        /// <summary>
        /// Gets or sets for number of rides
        /// </summary>
        public int NumberOfRides { get; set; }

        /// <summary>
        /// Gets or sets for total fare
        /// </summary>
        public double TotalFare { get; set; }

        /// <summary>
        /// Gets or sets for average fare per ride
        /// </summary>
        public double AverageFarePerRide { get; set; }

        /// <summary>
        /// to calculate average fare
        /// </summary>
        public void CalulateAverageFare()
        {
            this.AverageFarePerRide = this.TotalFare / this.NumberOfRides;
        }
    }
}
