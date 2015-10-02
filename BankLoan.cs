using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class BankLoan
    {
        [TestMethod]
        [TestCategory("04_Bank_Loan_With_Descending_Interest")]
        public void Compute_Rate_For_First_Month() {

            int paymentMonth = 10;
            Credit credit = new Credit(20000, 60, 16.04);


            decimal payment = GetPaymentForMonth(credit, paymentMonth);

            Assert.AreEqual("560.567", payment.ToString("#.###"));
        }

        private decimal GetPaymentForMonth(Credit credit, int paymentMonth) {
            decimal interest = GetIntrestForMonth(credit, paymentMonth);
            return credit.Principal + interest;
        }

        private decimal GetIntrestForMonth(Credit credit, int paymentMonth) {
            decimal balance = credit.GetBalance(paymentMonth);
            return balance * (decimal)(credit.Interest /100) / 12;
        }
    }

    public class Credit
    {
        private decimal amount;
        private int termInMonths;
        private double yearlyInterest;
        private decimal principal;

        public Credit(decimal amount, int termInMonths, double yearlyInterestInPercent) {
            this.amount = amount;
            this.termInMonths = termInMonths;
            this.yearlyInterest = yearlyInterestInPercent;

            this.principal = ComputePrincipal(amount);
        }

        private decimal ComputePrincipal(decimal toalAmount) {
            return this.amount / this.termInMonths;
        }

        public decimal Amount {
            get { return this.amount; }
        }

        public double Interest {
            get { return this.yearlyInterest; }
        }

        public int TermInMonths {
            get { return this.termInMonths; }
        }

        public decimal Principal {
            get { return this.principal; }
        }

        public decimal GetBalance(int paymentMonth) {
            return this.amount - (paymentMonth - 1) * this.principal;
        }
    }
}
