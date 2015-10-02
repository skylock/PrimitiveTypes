using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class ExcelColumns
    {
        // Solution taken from http://stackoverflow.com/questions/181596/how-to-convert-a-column-number-eg-127-into-an-excel-column-eg-aa

        [TestMethod]
        [TestCategory("02_Excel_Columns")]
        public void Column_Combination_If_Less_Than_27 () {
            int columnNumber = 2;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("B", columnID);
        }

        [TestMethod]
        [TestCategory("02_Excel_Columns")]
        public void Column_Combination_If_Equal_To_27() {
            int columnNumber = 27;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("AA", columnID);
        }

        [TestMethod]
        [TestCategory("02_Excel_Columns")]
        public void Column_Combination_If_Equal_To_52() {
            int columnNumber = 52;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("AZ", columnID);
        }

        [TestMethod]
        [TestCategory("02_Excel_Columns")]
        public void Column_Combination_If_Equal_To_53() {
            int columnNumber = 53;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("BA", columnID);
        }

        [TestMethod]
        [TestCategory("02_Excel_Columns")]
        public void Column_Combination_If_Equal_To_16384() {
            int columnNumber = 16384;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("XFD", columnID);
        }

        private string GetColumnID(int columnNumber) {
            string result = string.Empty;
            int divisionResult = columnNumber;
            int remainder;

            while (divisionResult > 0) {
                remainder = (divisionResult - 1) % 26;
                result = CovertDigitToChar(remainder) + result;
                divisionResult = (divisionResult - remainder) / 26;
            }
            return result;
        }

        private static string CovertDigitToChar(int digit) {
            return Convert.ToChar('A'  + digit).ToString();
        }
    }
}
