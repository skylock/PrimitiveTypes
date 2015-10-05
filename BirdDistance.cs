using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class BirdDistance
    {
        [TestMethod]
        [TestCategory("07_Bird_Distance")]
        public void Compute_Bird_Flown_Distance_When_Distance_Between_Trains_Less_Than_Zero()
        {
            double distanceBetwinTrains = -16;

            double birdFlownDistance = GetBirdFlownDistance(distanceBetwinTrains);

            Assert.AreEqual(0, birdFlownDistance);
        }

        [TestMethod]
        [TestCategory("07_Bird_Distance")]
        public void Compute_Bird_Flown_Distance_When_Distance_Between_Trains_Equal_To_Zero()
        {
            double distanceBetwinTrains = 0;

            double birdFlownDistance = GetBirdFlownDistance(distanceBetwinTrains);

            Assert.AreEqual(0, birdFlownDistance);
        }

        [TestMethod]
        [TestCategory("07_Bird_Distance")]
        public void Compute_Bird_Flown_Distance_When_Distance_Between_Trains_Bigger_Than_Zero()
        {
            double distanceBetwinTrains = 16;

            double birdFlownDistance = GetBirdFlownDistance(distanceBetwinTrains);

            Assert.AreEqual(8, birdFlownDistance);
        }

        private double GetBirdFlownDistance(double distanceBetwinTrains)
        {
            return distanceBetwinTrains <=0 ? 0 : distanceBetwinTrains / 2;
        }
    }
}
