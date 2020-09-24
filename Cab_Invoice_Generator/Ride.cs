//-----------------------------------------------------------------------
// <copyright file="Ride.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cab_Invoice_Generator
{
    /// <summary>
    /// Ride Class
    /// </summary>
    public class Ride
    {
        /// <summary>
        /// variable for distance
        /// </summary>
        private double distance;

        /// <summary>
        /// variable for time
        /// </summary>
        private int time;

        /// <summary>
        /// variable for ride type
        /// </summary>
        private string rideType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride" /> class.
        /// </summary>
        /// <param name="rideType">rideType in string.</param>
        /// <param name="distance">distance in double. </param>
        /// <param name="time">time in integer.</param>
        public Ride(string rideType, double distance, int time)
        {
            this.RideType = rideType;
            this.Distance = distance;
            this.Time = time;
        }

        /// <summary>
        /// Gets or sets time
        /// </summary>
        public int Time { get => this.time; set => this.time = value; }

        /// <summary>
        /// Gets or sets ride type
        /// </summary>
        public string RideType { get => this.rideType; set => this.rideType = value; }

        /// <summary>
        /// Gets or sets distance
        /// </summary>
        public double Distance { get => this.distance; set => this.distance = value; }
    }
}
