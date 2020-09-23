namespace Cab_Invoice_Generator
{
    using System.Collections.Generic;

    public class RideRepository
    {
        private readonly Dictionary<string, List<Ride>> userRideObj = new Dictionary<string, List<Ride>>();
        /// <summary>
        /// AddRide method for adding rides 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Ride[] rides)
        {
            bool checkRide = this.userRideObj.ContainsKey(userId);
            if (checkRide == false)
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                this.userRideObj.Add(userId, list);
            }
        }

        /// <summary>
        /// getting the rides of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Ride[] GetRides(string userId)
        {
            return this.userRideObj[userId].ToArray();
        }
    }
}