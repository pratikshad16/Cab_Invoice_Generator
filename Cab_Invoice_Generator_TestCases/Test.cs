//-----------------------------------------------------------------------
// <copyright file="Test.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cab_Invoice_Generator_TestCases
{
    using Cab_Invoice_Generator;
    using NUnit.Framework;

    /// <summary>
    /// Test class
    /// </summary>
    public class Test
    {
        /// <summary>
        /// object of cab invoice generator
        /// </summary>
        private readonly CabInvoiceGenerator invoice = new CabInvoiceGenerator();

        /// <summary>
        /// object of ride repository
        /// </summary>
        private readonly RideRepository rideRepository = new RideRepository();

        /// <summary>
        /// object of cab invoice generator
        /// </summary>
        private readonly CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();

        /// <summary>
        /// setup method
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }
        
        /// <summary>
        /// test method 1 
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = this.cabInvoiceGenerator.CalculateFare("normal", distance, time);
            Assert.AreEqual(25, fare, delta: 0.0);
        }

        /// <summary>
        /// test method 2 
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double fare = this.cabInvoiceGenerator.CalculateFare("normal", distance, time);
            Assert.AreEqual(5, fare, delta: 0.0);
        }

        /// <summary>
        /// test method 3 
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            Ride[] rides =
                {
                    new Ride("normal", 2.0, 5),
                    new Ride("normal", 0.1, 1)
                };
            InvoiceSummary summary = this.cabInvoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(30, summary.TotalFare);
        }

        /// <summary>
        /// test method 4
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeOfMultiRidesToInvoiceGeneratorShouldInhancedInvoice()
        {
            // sending two rides distance in double and  time in int
            Ride[] rides =
            {
                new Ride("normal", 2.0, 5),
                new Ride("normal", 0.1, 1)
            };
            InvoiceSummary returnSummery = this.invoice.CalculateFare(rides);
            InvoiceSummary expectedSummery = new InvoiceSummary
            {
                NumberOfRides = 2,
                TotalFare = 30,
                AverageFarePerRide = 15
            };
            Assert.AreEqual(returnSummery.TotalFare, expectedSummery.TotalFare);
            Assert.AreEqual(expectedSummery.NumberOfRides, returnSummery.NumberOfRides);
            Assert.AreEqual(expectedSummery.AverageFarePerRide, returnSummery.AverageFarePerRide);
        }

        /// <summary>
        /// test method 5 
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeOfMultiRidesToUserId_ShouldTotalFare()
        {
            string userId = "pratiksha@123";
            Ride[] rides =
            {
                    new Ride("normal", 2.0, 5),
                    new Ride("normal", 0.1, 1)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, rides);
            InvoiceSummary retunTotal = this.invoice.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(30, retunTotal.TotalFare);
        }

        /// <summary>
        /// test method 6
        /// </summary>
        [Test]
        public void GivenUserIdOfMultiRidesToUserId_ShouldTotalFare()
        {
            string userId = "Pranali@123";
            Ride[] rides =
            {
                new Ride("normal", 2.0, 1),
                new Ride("premium", 2.5, 1)
            };
            this.rideRepository.AddRides(userId, rides);
            InvoiceSummary retunTotal = this.invoice.CalculateFare(this.rideRepository.GetRides(userId));
            Assert.AreEqual(60.5, retunTotal.TotalFare);
        }
    }
}