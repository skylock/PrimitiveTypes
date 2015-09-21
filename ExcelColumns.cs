using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class ExcelColumns
    {
        public const int LETTERS_COUNT = 26;

        [TestMethod]
        [TestCategory("02_ExcelColumns")]
        public void Column_Combination_If_Less_Than_27 () {
            int columnNumber = 2;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("B", columnID);
        }

        [TestMethod]
        [TestCategory("02_ExcelColumns")]
        public void Column_Combination_If_Equal_To_27() {
            int columnNumber = 27;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("AA", columnID);
        }

        [TestMethod]
        [TestCategory("02_ExcelColumns")]
        public void Column_Combination_If_Equal_To_52() {
            int columnNumber = 52;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("AZ", columnID);
        }

        [TestMethod]
        [TestCategory("02_ExcelColumns")]
        public void Column_Combination_If_Equal_To_53() {
            int columnNumber = 53;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("BA", columnID);
        }

        private string GetColumnID(int columnNumber) {
            string result = string.Empty;
            int divisionResult = columnNumber / LETTERS_COUNT;
            int remainder = columnNumber % LETTERS_COUNT;
            if (divisionResult < 1) {
                return result + GetChar(columnNumber);
            } else {
                result = result + GetChar(divisionResult);
                result = result + GetChar(remainder);
                return result;
            } 
        }

        private static char GetChar(int index) {
            return (char)(('A' - 1)  + index);
        }
    }
}
