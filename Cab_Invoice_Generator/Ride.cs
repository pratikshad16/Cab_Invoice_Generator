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
        public double Distance;

        /// <summary>
        /// variable for time
        /// </summary>
        public int Time;

        /// <summary>
        /// variable for ride type
        /// </summary>
        public string RideType;

        /// <summary>
        /// constructor for multiple rides
        /// </summary>
        /// <param name="rideType">rideType in string.</param>
        /// <param name="distance">distance in double.</param>
        /// <param name="time">time in double.</param>
        public Ride(string rideType, double distance, int time)
        {
            this.RideType = rideType;
            this.Distance = distance;
            this.Time = time;
        }
    }
}
