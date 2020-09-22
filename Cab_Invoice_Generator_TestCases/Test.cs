using Cab_Invoice_Generator;
using NUnit.Framework;

namespace Cab_Invoice_Generator_TestCases
{
    public class Tests
    {
        CabInvoiceGenerator invoice = new CabInvoiceGenerator();
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
            double fare = cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(25, fare, delta: 0.0);
        }
        [Test]
        public void GivenDistanceAndTime_ShouldReturnMinimumFare()
        {
            CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();
            double distance = 0.1;
            int time = 1;
            double fare = cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5, fare, delta: 0.0);
        }
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();
            Ride[] rides = {
                new Ride(2.0, 5),
                new Ride(0.1, 1)
                };
            InvoiceSummary summary = cabInvoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(30,summary.totalFare);
        }
        [Test]
        public void GivenDistanceAndTimeOfMultiRidesToInvoiceGeneratorShouldInhancedInvoice()
        {
            // Local variables
            bool exceptedInvoice = true;
            bool returnInvoice = false;
            // sending two rides distance in double and  time in int
            Ride[] rides =
            {
                new Ride(2.0,5),
                new Ride(0.1,1)
            };
            InvoiceSummary returnSummery = invoice.CalculateFare(rides);
            InvoiceSummary expectedSummery = new InvoiceSummary
            {
                numberOfRides = 2,
                totalFare = 30,
                averageFarePerRide = 15
            };
            //Checkoing all three returnSummary values are equal to exceptedSummary
            //if yes then returnInvoice will be 'true'
            if (returnSummery.numberOfRides == expectedSummery.numberOfRides && returnSummery.totalFare == expectedSummery.totalFare && returnSummery.averageFarePerRide == expectedSummery.averageFarePerRide)
            {
                returnInvoice = true;
            }
            Assert.AreEqual(exceptedInvoice, returnInvoice);
        }
    }
}