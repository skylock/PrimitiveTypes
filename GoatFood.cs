using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class GoatFood
    {
        [TestMethod]
        [TestCategory("08_Goat_Food")]
        public void Compute_Food_Needed_For_Zero_Days() {
            int rDays = 0;
            int rGoats = 4;
            int rNeededHayInKg = 8;

            int neededHayInKg = ComputeNeededHayInKg(rDays, rGoats, rNeededHayInKg, 1, 2);

            Assert.AreEqual(0, neededHayInKg);
        }

        [TestMethod]
        [TestCategory("08_Goat_Food")]
        public void Compute_Food_Needed_For_Zero_Goats() {
            int rDays = 2;
            int rGoats = 0;
            int rNeededHayInKg = 8;

            int neededHayInKg = ComputeNeededHayInKg(rDays, rGoats, rNeededHayInKg, 1, 2);

            Assert.AreEqual(0, neededHayInKg);
        }

        [TestMethod]
        [TestCategory("08_Goat_Food")]
        public void Compute_Food_Needed_For_Goats_When_All_Values_More_Than_Zero() {
            int rDays = 2;
            int rGoats = 4;
            int rNeededHayInKg = 8;

            int neededHayInKg = ComputeNeededHayInKg(rDays, rGoats, rNeededHayInKg, 1, 2);

            Assert.AreEqual(4, neededHayInKg);
        }

        private int ComputeNeededHayInKg(int rDays, int rGoats, int rNeededHayInKg, int days, int goats) {
            return rGoats > 0 && rDays > 0 ? (days * rGoats * rNeededHayInKg) / (rDays * rGoats) : 0;
        }
    }
}
