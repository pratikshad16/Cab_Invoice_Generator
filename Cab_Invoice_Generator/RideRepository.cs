//-----------------------------------------------------------------------
// <copyright file="RideRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cab_Invoice_Generator
{
    using System.Collections.Generic;

    /// <summary>
    /// Ride repository Class
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// Dictionary for storing string and list
        /// </summary>
        private readonly Dictionary<string, List<Ride>> userRideObj = new Dictionary<string, List<Ride>>();

        /// <summary>
        /// AddRide method for adding rides 
        /// </summary>
        /// <param name="userId">userId in string.</param>
        /// <param name="rides">rides in array.</param>
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
        /// <param name="userId"> userId in string.</param>
        /// <returns>user ride object.</returns>
        public Ride[] GetRides(string userId)
        {
            return this.userRideObj[userId].ToArray();
        }
    }
}