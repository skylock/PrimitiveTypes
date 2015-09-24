using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class Watermelon
    {
        [TestMethod]
        [TestCategory("05_Watermelon")]
        public void Cant_Be_Splited_If_Weight_Is_Less_Than_Four() {
            int weight = 2;

            bool canBeSplited = CanBeSplited(weight);

            Assert.IsFalse(canBeSplited);
        }
        
        [TestMethod]
        [TestCategory("05_Watermelon")]
        public void Cant_Be_Splited_If_Weight_Is_Not_Divisible_By_Two() {
            int weight = 13;

            bool canBeSplited = CanBeSplited(weight);

            Assert.IsFalse(canBeSplited);
        }

        [TestMethod]
        [TestCategory("05_Watermelon")]
        public void Can_Be_Splited_If_Weight_Is_Divisible_By_Two() {
            int weight = 14;

            bool canBeSplited = CanBeSplited(weight);

            Assert.IsTrue(canBeSplited);
        }

        private bool CanBeSplited(int weight) {
            if (weight >= 4) {
                return weight % 2 == 0;
            } else {
                return false;
            }
        }
    }
}

