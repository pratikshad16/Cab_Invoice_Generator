using Cab_Invoice_Generator;
using NUnit.Framework;

namespace Cab_Invoice_Generator_TestCases
{
    public class Tests
    {
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
    }
}