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
            int expected = 9;
            int cBase = 2;

            byte[] result = ConvertToBase(expected, cBase);
            int actual = ConvertFromBase(result, cBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Convert_From_Base_10_To_Base_2_No_1119() {
            int expected = 1119;
            int cBase = 2;

            byte[] result = ConvertToBase(expected, cBase);
            int actual = ConvertFromBase(result, cBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Convert_From_Base_10_To_Base_2_No_172() {
            int expected = 172;
            int cBase = 2;

            byte[] result = ConvertToBase(expected, cBase);
            int actual = ConvertFromBase(result, cBase);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Convert_From_Base_8_To_Base_10_No_172() {
            int expected = 172;
            int cBase = 8;

            byte[] result = ConvertToBase(expected, cBase);
            int actual = ConvertFromBase(result, cBase);

            Assert.AreEqual(expected, actual);
        }

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
        private int ConvertFromBase(byte[] value, int fromBase)
        {
            int result = 0;
            for(int i = value.Length; i > 0; i--)
            {
                byte cellVaue = value[i - 1];
                result += cellVaue * (int)Math.Pow(fromBase, value.Length - i);
            }
            return result;
        }
    }
}
