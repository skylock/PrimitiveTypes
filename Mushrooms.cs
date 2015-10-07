using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class Mushrooms
    {
        [TestMethod]
        [TestCategory("09_Mushrooms_Count")]
        public void Count_Mushrooms_When_Multiplication_Factor_Is_Zero() {
            int white = 3;
            int red = 6;
            Tuple<int, int> actualCount = new Tuple<int, int>(white, red);
            int totalMushrooms = 9;
            int multilicationFactor = 0;

            Tuple<int, int> mushroomsCounted = CountMushrooms(totalMushrooms, multilicationFactor);

            Assert.AreEqual(mushroomsCounted, actualCount);
        }

        [TestMethod]
        [TestCategory("09_Mushrooms_Count")]
        public void Count_Mushrooms_When_All_Input_Values_Are_More_Than_Zero() {
            int white = 3;
            int red = 6;
            Tuple<int, int> actualCount = new Tuple<int, int>(white, red);
            int totalMushrooms = 9;
            int multilicationFactor = 2;

             Tuple<int, int> mushroomsCounted = CountMushrooms(totalMushrooms, multilicationFactor);

            Assert.AreEqual(mushroomsCounted, actualCount);
        }

        private Tuple<int, int> CountMushrooms(int totalMushrooms, int multiplicationFactor) {
            int whiteCount = totalMushrooms / (multiplicationFactor + 1);
            int redCount = (totalMushrooms * multiplicationFactor) / (multiplicationFactor + 1);
            if (multiplicationFactor > 0) {
                return new Tuple<int, int>(whiteCount, redCount);
            } else {
                throw new Exception("Multiplication factor should be grater than zero.");
            }
        }
    }
}
