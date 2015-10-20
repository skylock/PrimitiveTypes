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
        public void Convert_From_Base_10_To_A_Base_Lower_Than_2() {
            byte[] result = ConvertToBase(9, 0);
        }
        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Convert_From_Base_10_To_Base_2_No_9() {
            string expected = Convert.ToString(9, 2);
            
            byte[] result = ConvertToBase(9,2);
            string actual = GetString(result);

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //[TestCategory("13_Convert_To_Base")]
        //public void Convert_From_Base_10_To_Base_2_No_172() {
        //    string expected = Convert.ToString(172, 2);

        //    string actual = ConvertToBase(172, 2);

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //[TestCategory("13_Convert_To_Base")]
        //public void Convert_From_Base_2_To_Base_10_No_172()
        //{
        //    string expected = Convert.ToString(172, 2);

        //    string actual = ConvertFromBase(expected, 10);

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //[TestCategory("13_Convert_To_Base")]
        //public void Convert_From_Base_8_To_Base_10_No_13()
        //{
        //    string expected = Convert.ToString(13, 8);

        //    string actual = ConvertFromBase(expected, 10);

        //    Assert.AreEqual(expected, actual);
        //}


        /// <summary>
        /// Converts a number from base 10 to any base.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="toBase">To base.</param>
        /// <returns></returns>
        private byte[] ConvertToBase(int value, int toBase) {
            if (toBase < 2) throw new ArgumentException("Invalid base.");
            int i = 0;
            int baseSize = 8;
            byte[] bytes = new byte[baseSize];
            int divisionResult = value;
            int remainder;

            while (divisionResult > 0) {
                if (i == bytes.Length) Array.Resize(ref bytes, bytes.Length + baseSize);
                remainder = divisionResult  % toBase;
                bytes[i] = (byte)remainder;
                divisionResult = (divisionResult - remainder) / toBase;
                i++;
            }
            Array.Reverse(bytes);
            return bytes;
        }

        /// <summary>
        /// Converts a number from any base to base 10.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="fromBase">From base.</param>
        /// <returns></returns>
        private string ConvertFromBase(string value, int fromBase)
        {
            double result = 0;
            for(int i = value.Length; i > 0; i--)
            {
                char ch = value[i - 1];
                result += (int)Char.GetNumericValue(ch) * Math.Pow(fromBase, value.Length - i);
            }
            return result.ToString();
        }

        static string GetString(byte[] bytes) {
            string result = string.Empty;
            for (int i = 0; i < bytes.Length; i++) {
                result += bytes[i];
            }
            return result;
        }
    }
}
