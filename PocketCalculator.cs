namespace PrimitiveTypes
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PocketCalculator
    {
        [TestMethod]
        [TestCategory("16_PocketCalculator")]
        [ExpectedException(typeof(ArgumentException))]
        public void Compute_StringIsEmpty_ReturnsEmptyString() {
            string value = string.Empty;

            double actual = Compute(value);
        }

        [TestMethod]
        [TestCategory("16_PocketCalculator")]
        public void Compute_SimpleOperationForTwoNumbers_ReturnsResult() {
            string input = "* 3 4";

            double result = Compute(input);

            Assert.AreEqual(12, result, 0);
        }

        private double Compute(string input) {
            if (String.IsNullOrEmpty(input)) return 0;
            return 0;
        }
    }
}
