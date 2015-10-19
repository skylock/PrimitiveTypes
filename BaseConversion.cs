using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace PrimitiveTypes
{
    [TestClass]
    public class BaseConversion
    {
        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_To_Base_2_No_9() {
            uint value = 9;
            uint  _base = 2;
            string expected = Convert.ToString(value, 2);
            
            string result = ConvertToBase(value, _base);

            Assert.AreEqual(expected, result);
        }

        private string ConvertToBase(uint value, uint _base) {
            return string.Empty;
        }
    }
}
