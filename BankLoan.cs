namespace PrimitiveTypes
{
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BankLoan
    {
        [TestMethod]
        [TestCategory("04_Bank_Loan_With_Descending_Interest")]
        public void Compute_For_Less_Than_A_Months() {
            Credit credit = new Credit(40000, 7.57, 0);

            decimal payment = credit.GetPaymentForMonth(0);

            Assert.AreEqual(40000, (double)Decimal.Round(payment, 2));
        }

        [TestMethod]
        [TestCategory("04_Bank_Loan_With_Descending_Interest")]
        public void Compute_For_Zero_Interest() {
            Credit credit = new Credit(40000, 0, 240);

            decimal payment = credit.GetPaymentForMonth(51);

            Assert.AreEqual(166.67, (double)Decimal.Round(payment, 2));
        }

        [TestMethod]
        [TestCategory("04_Bank_Loan_With_Descending_Interest")]
        public void Compute_For_Zero_Credit() {
            Credit credit = new Credit(0, 7.57, 240);

            decimal payment = credit.GetPaymentForMonth(51);

            Assert.AreEqual(0, (double)Decimal.Round(payment, 2));
        }

        [TestMethod]
        [TestCategory("04_Bank_Loan_With_Descending_Interest")]
        public void Compute_For_3rd_Month_Of_4th_Year() 
        {
            Credit credit = new Credit(40000, 7.57, 240);

            decimal payment = credit.GetPaymentForMonth(51);

            Assert.AreEqual(366.43, (double)Decimal.Round(payment, 2));
        }

        [TestMethod]
        [TestCategory("04_Bank_Loan_With_Descending_Interest")]
        public void Get_Credit_Term_In_Months() 
        {
            Credit credit = new Credit(40000, 7.57, 240);

            Assert.AreEqual(240, credit.TermInMonths);
        }

        [TestMethod]
        [TestCategory("04_Bank_Loan_With_Descending_Interest")]
        public void Get_Credit_Amount() 
        {
            Credit credit = new Credit(40000, 7.57, 240);

            Assert.AreEqual(40000, credit.Amount);
        }
        
        public class Credit
    {
        private const int MonthsInYear = 12;
        private decimal amount;
        private int termInMonths;
        private double yearlyInterest;
        private decimal principal;

        public Credit(decimal amount, double yearlyInterestInPercent, int termInMonths) 
        {
            this.amount = amount;
            this.termInMonths = termInMonths;
            this.yearlyInterest = yearlyInterestInPercent;
            this.principal = this.ComputePrincipal(amount);
        }

        public decimal Amount 
        {
            get { return this.amount; }
        }

        public double Interest 
        {
            get { return this.yearlyInterest; }
        }

        public int TermInMonths 
        {
            get { return this.termInMonths; }
        }
        
        private decimal Principal 
        {
            get { return this.principal; }
        }
        
        public decimal GetBalance(int paymentMonth) 
        {
            return this.amount - ((paymentMonth - 1) * this.principal);
        }

        public decimal GetPaymentForMonth(int paymentMonth) 
        {
            return paymentMonth > 0 ? this.Principal + this.GetIntrestForMonth(paymentMonth) : this.amount;
        }

        public decimal GetIntrestForMonth(int paymentMonth) 
        {
            decimal balance = this.GetBalance(paymentMonth);
            return balance * (decimal)(this.Interest / 100) / MonthsInYear;
        }

        private decimal ComputePrincipal(decimal toalAmount) 
        {
            return this.termInMonths > 0 ? this.amount / this.termInMonths : 0;
        }
    }
    }
}
