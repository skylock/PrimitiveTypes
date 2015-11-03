namespace PrimitiveTypes
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PocketCalculator
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsResult() {
            string input = "+ 3 4";

            double result = Compute(input);

            Assert.AreEqual(7, result, 0);
        }

        private double Compute(string input) {
            throw new NotImplementedException();
        }
    }
}
