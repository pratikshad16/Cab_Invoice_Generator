using Cab_Invoice_Generator;
using NUnit.Framework;

namespace Cab_Invoice_Generator_TestCases
{
    public class Tests
    {
        CabInvoiceGenerator invoice = new CabInvoiceGenerator();
        RideRepository rideRepository = new RideRepository();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();
            double distance = 2.0;
            int time = 5;
            double fare = cabInvoiceGenerator.CalculateFare("normal", distance, time);
            Assert.AreEqual(25, fare, delta: 0.0);
        }
        [Test]
        public void GivenDistanceAndTime_ShouldReturnMinimumFare()
        {
            CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();
            double distance = 0.1;
            int time = 1;
            double fare = cabInvoiceGenerator.CalculateFare("normal", distance, time);
            Assert.AreEqual(5, fare, delta: 0.0);
        }
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();
            Ride[] rides = {
                new Ride("normal",2.0, 5),
                new Ride("normal",0.1, 1)
                };
            InvoiceSummary summary = cabInvoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(30, summary.totalFare);
        }
        [Test]
        public void GivenDistanceAndTimeOfMultiRidesToInvoiceGeneratorShouldInhancedInvoice()
        {
            // sending two rides distance in double and  time in int
            Ride[] rides =
            {
                new Ride("normal",2.0,5),
                new Ride("normal",0.1,1)
            };
            InvoiceSummary returnSummery = invoice.CalculateFare(rides);
            InvoiceSummary expectedSummery = new InvoiceSummary
            {
                numberOfRides = 2,
                totalFare = 30,
                averageFarePerRide = 15
            };
            Assert.AreEqual(returnSummery.totalFare, expectedSummery.totalFare);
            Assert.AreEqual(expectedSummery.numberOfRides, returnSummery.numberOfRides);
            Assert.AreEqual(expectedSummery.averageFarePerRide, returnSummery.averageFarePerRide);
        }
        [Test]
        public void GivenDistanceAndTimeOfMultiRidesToUserId_ShouldTotalFare()
        {
            string userId = "pratiksha@123";
            Ride[] rides =
            {
                    new Ride("normal",2.0,5),
                    new Ride("normal",0.1,1)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, rides);
            InvoiceSummary retunTotal = invoice.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(30, retunTotal.totalFare);
        }
        [Test]
        public void GivenUserIdOfMultiRidesToUserId_ShouldTotalFare()
        {
            string userId = "Pranali@123";
            Ride[] rides =
            {
                new Ride("normal",2.0,1),
                new Ride("premium",2.5,1)
            };
            rideRepository.AddRides(userId, rides);
            InvoiceSummary retunTotal = invoice.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(60.5, retunTotal.totalFare);
        }
    }
}