using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class Mushrooms
    {
        [TestMethod]
        [TestCategory("09_Mushrooms_Count")]
        public void Count_Mushrooms_When_Multiplication_Factor_Is_Negative() {
            Tuple<int, int> actualCount = new Tuple<int, int>(-1, -1);
            int totalMushrooms = 1;
            int multilicationFactor = -5;

            Tuple<int, int> mushroomsCounted = CountMushrooms(totalMushrooms, multilicationFactor);

            Assert.AreEqual(mushroomsCounted, actualCount);
        }

        [TestMethod]
        [TestCategory("09_Mushrooms_Count")]
        public void Count_Mushrooms_When_Total_Mushrooms_And_Multiplication_Factor_Is_Zero() {
            Tuple<int, int> actualCount = new Tuple<int, int>(-1, -1);
            int totalMushrooms = 0;
            int multilicationFactor = 0;

            Tuple<int, int> mushroomsCounted = CountMushrooms(totalMushrooms, multilicationFactor);

            Assert.AreEqual(mushroomsCounted, actualCount);
        }

        [TestMethod]
        [TestCategory("09_Mushrooms_Count")]
        public void Count_Mushrooms_When_Total_Mushrooms_Is_Zero() {
            Tuple<int, int> actualCount = new Tuple<int, int>(-1, -1);
            int totalMushrooms = 0;
            int multilicationFactor = 4;

            Tuple<int, int> mushroomsCounted = CountMushrooms(totalMushrooms, multilicationFactor);

            Assert.AreEqual(mushroomsCounted, actualCount);
        }

        [TestMethod]
        [TestCategory("09_Mushrooms_Count")]
        public void Count_Mushrooms_When_Multiplication_Factor_Determins_Division_With_Remainder()
        {
            Tuple<int, int> actualCount = new Tuple<int, int>(-1, -1);
            int totalMushrooms = 8;
            int multilicationFactor = 4;

            Tuple<int, int> mushroomsCounted = CountMushrooms(totalMushrooms, multilicationFactor);

            Assert.AreEqual(mushroomsCounted, actualCount);
        }

        [TestMethod]
        [TestCategory("09_Mushrooms_Count")]
        public void Count_Mushrooms_When_Multiplication_Factor_Is_Zero() {
             Tuple<int, int> actualCount = new Tuple<int, int>(-1, -1);
            int totalMushrooms = 9;
            int multilicationFactor = 0;

            Tuple<int, int> mushroomsCounted = CountMushrooms(totalMushrooms, multilicationFactor);

            Assert.AreEqual(mushroomsCounted, actualCount);
        }

        [TestMethod]
        [TestCategory("09_Mushrooms_Count")]
        public void Count_Mushrooms_When_All_Input_Values_Are_More_Than_Zero() {
            Tuple<int, int> actualCount = new Tuple<int, int>(3, 6);
            int totalMushrooms = 9;
            int multilicationFactor = 2;

             Tuple<int, int> mushroomsCounted = CountMushrooms(totalMushrooms, multilicationFactor);

            Assert.AreEqual(mushroomsCounted, actualCount);
        }

        private Tuple<int, int> CountMushrooms(int totalMushrooms, int multiplicationFactor) {
            bool validData = ValidateInputData(totalMushrooms, multiplicationFactor);
            if (validData){
                int whiteCount = totalMushrooms / (multiplicationFactor + 1);
                int redCount = (totalMushrooms * multiplicationFactor) / (multiplicationFactor + 1);
                return new Tuple<int, int>(whiteCount, redCount);
            }
            return new Tuple<int, int>(-1, -1);
        }

        private bool ValidateInputData(int totalMushrooms, int multiplicationFactor) {
            bool totalMushroomsIsNotZeroOrNegative = totalMushrooms > 0;
            bool divisionHaveNoRemainder = totalMushrooms % (multiplicationFactor + 1) == 0;
            bool validMultiplicationFactor = multiplicationFactor > 0;
            return totalMushroomsIsNotZeroOrNegative && divisionHaveNoRemainder && validMultiplicationFactor;
        }
    }
}
