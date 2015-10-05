using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class GoatFood
    {
        [TestMethod]
        [TestCategory("08_Goat_Food")]
        public void Compute_Food_Needed_For_Tim_Data() {
            double rDays = 2;
            double rGoats = 4;
            double rNeededHayInKg = 8;

            double neededHayInKg = ComputeNeededHayInKg(rDays, rGoats, rNeededHayInKg, 1, 2);

            Assert.AreEqual(2, neededHayInKg);
        }

        [TestMethod]
        [TestCategory("08_Goat_Food")]
        public void Compute_Food_Needed_For_Zero_Days() {
            double rDays = 0;
            double rGoats = 4;
            double rNeededHayInKg = 8;

            double neededHayInKg = ComputeNeededHayInKg(rDays, rGoats, rNeededHayInKg, 1, 2);

            Assert.AreEqual(0, neededHayInKg);
        }

        [TestMethod]
        [TestCategory("08_Goat_Food")]
        public void Compute_Food_Needed_For_Zero_Goats() {
            double rDays = 2;
            double rGoats = 0;
            double rNeededHayInKg = 8;

            double neededHayInKg = ComputeNeededHayInKg(rDays, rGoats, rNeededHayInKg, 1, 2);

            Assert.AreEqual(0, neededHayInKg);
        }

        [TestMethod]
        [TestCategory("08_Goat_Food")]
        public void Compute_Food_Needed_For_Goats_When_All_Values_More_Than_Zero() {
            double rDays = 2;
            double rGoats = 4;
            double rNeededHayInKg = 8;

            double neededHayInKg = ComputeNeededHayInKg(rDays, rGoats, rNeededHayInKg, 1, 2);

            Assert.AreEqual(2, neededHayInKg);
        }

        private double ComputeNeededHayInKg(double rDays, double rGoats, double rNeededHayInKg, double days, double goats) {
            return rGoats > 0 && rDays > 0 ? (days * goats * rNeededHayInKg) / (rDays * rGoats) : 0;
        }
    }
}
