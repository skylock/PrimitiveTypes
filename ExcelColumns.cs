using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class ExcelColumns
    {
        [TestMethod]
        [TestCategory("02_ExcelColumns")]
        public void Compute_Combination_For_Column_Number_Less_Than_27 () {
            int columnNumber = 2;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("B", columnID);

        }

        [TestMethod]
        [TestCategory("02_ExcelColumns")]
        public void Compute_Combination_For_Column_Number_Equal_To_27() {
            int columnNumber = 27;

            string columnID = GetColumnID(columnNumber);

            Assert.AreEqual("AA", columnID);

        }

        private string GetColumnID(int columnNumber) {
            string result = string.Empty;
            return result + GetChar(columnNumber);
        }

        private static char GetChar(int index) {
            return (char)(('A' - 1) + index);
        }
    }
}
