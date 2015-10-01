using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class BankLoan
    {
        [TestMethod]
        public void Compute_Rate_For_First_Month() {

            decimal credit = 20000;
                int months = 60;
            double intrest = 16.04;

            double payment = ComputePayment(credit, months, intrest);

            Assert.AreEqual(0, payment);
        }

        private double ComputePayment(decimal credit, int months, double intrest) {

        }
    }
}
