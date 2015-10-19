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
        public void Convert_To_A_Base_Lower_Than_2() {
            string result = ConvertToBase(9, 0);
        }
        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Convert_To_Base_2_No_9() {
            string expected = Convert.ToString(9, 2);
            
            string result = ConvertToBase(9,2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Convert_To_Base_2_No_172() {
            string expected = Convert.ToString(172, 2);

            string result = ConvertToBase(172, 2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Convert_From_Base_2_To_Base_10_No_172()
        {
            string binaryString = Convert.ToString(172, 2);

            double result = ConvertToBase10(binaryString, 2);

            Assert.AreEqual(172, result);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Convert_From_Base_8_To_Base_10_No_13()
        {
            string value = Convert.ToString(10, 8);

            double result = ConvertToBase10(value, 8);

            Assert.AreEqual(10, result);
        }


        /// <summary>
        /// Converts a number from base 10 to any base.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="toBase">The output base.</param>
        /// <returns></returns>
        private string ConvertToBase(int value, int toBase) {
            if (toBase < 2) throw new ArgumentException("Invalid base.");
            string result = string.Empty;
            int divisionResult = value;
            int remainder;

            while (divisionResult > 0) {
                remainder = divisionResult  % toBase;
                result = remainder + result;
                divisionResult = (divisionResult - remainder) / toBase;
            }
            return result;
        }

        private double ConvertToBase10(string value, int fromBase)
        {
            double result = 0;
            for(int i = value.Length; i > 0; i--)
            {
                char ch = value[i - 1];
                result += (int)Char.GetNumericValue(ch) * Math.Pow(fromBase, value.Length - i);
            }

            return result;
        }

    }
}
