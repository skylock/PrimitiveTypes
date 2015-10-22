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

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Test_Bitwise_NOT() {
            byte[] actual = ConvertToBase(4, 2);
            byte[] expected = { 1, 1, 0, 1, 1, 1, 1, 1 };
            
            NOT(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Test_Bitwise_AND_When_Params_Have_Same_Length() {
            int expected = 4 & 4;
            byte[] first = ConvertToBase(4, 2);
            byte[] second = ConvertToBase(4, 2);

            int actual = ConvertFromBase(AND(first, second), 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Test_Bitwise_AND_When_Params_Have_Different_Lengths() {
            int expected = 255 & 384;
            byte[] first = ConvertToBase(255, 2);
            byte[] second = ConvertToBase(384, 2);

            int actual = ConvertFromBase(AND(first, second), 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Test_Bitwise_AND_When_Params_Have_Different_Lengths2() {
            int expected = 255 & 256;
            byte[] first = ConvertToBase(255, 2);
            byte[] second = ConvertToBase(256, 2);

            int actual = ConvertFromBase(AND(first, second), 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Test_Bitwise_OR_When_Params_Have_Same_Length() {
            int expected = 6 | 8;
            byte[] first = ConvertToBase(6, 2);
            byte[] second = ConvertToBase(8, 2);

            int actual = ConvertFromBase(OR(first, second), 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Test_Bitwise_OR_When_Params_Have_Different_Lengths() {
            int expected = 255 | 384;
            byte[] first = ConvertToBase(255, 2);
            byte[] second = ConvertToBase(384, 2);

            int actual = ConvertFromBase(OR(first, second), 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Test_Bitwise_XOR_When_Params_Have_Same_Length() {
            int expected = 6 ^ 8;
            byte[] first = ConvertToBase(6, 2);
            byte[] second = ConvertToBase(8, 2);

            int actual = ConvertFromBase(XOR(first, second), 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Test_Bitwise_XOR_When_Params_Have_Different_Lengths() {
            int expected = 255 ^ 384;
            byte[] first = ConvertToBase(255, 2);
            byte[] second = ConvertToBase(384, 2);

            int actual = ConvertFromBase(XOR(first, second), 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("13_Convert_To_Base")]
        public void Test_Bitwise_Left_Shift() {
            byte[] bytes = ConvertToBase(2, 2);
            byte[] expected = ConvertToBase(2 << 5, 2);

            byte[] actual = LeftShift(bytes, 5);

            Assert.AreEqual(expected, actual);
        }

        private byte[] LeftShift(byte[] bytes, int numberOfBits) {
            throw new NotImplementedException();
        }

        private byte[] XOR(byte[] first, byte[] second) {
            int minSize = Math.Min(first.Length, second.Length);
            byte[] result = GetLargerArray(first, second);
            for (int i = 0; i < minSize; i++) {
                result[i] = (byte)((first[i] + second[i] == 1) ? 1 : 0);
            }
            return result;
        }

        private byte[] OR(byte[] first, byte[] second) {
            int minSize = Math.Min(first.Length, second.Length);
            byte[] result = GetLargerArray(first, second);
            for (int i = 0; i < minSize; i++) {
                if (first[i] + second[i] > 0) result[i] = 1;
            }
            return result;
        }

        private byte[] AND(byte[] first, byte[] second) {
            int maxSize = Math.Max(first.Length, second.Length);
            int minSize = Math.Min(first.Length, second.Length);
            byte[] result = new byte[maxSize];
            for (int i = 0; i < minSize; i++) {
                 result[i] = (byte)(first[i] * second[i]);
            }
            return result;
        }

        private void NOT(byte[] bytes) {
            for (int i = 0; i < bytes.Length; i++) {
                bytes[i] = (byte)((bytes[i] == 0) ? 1 : 0);
            }
        }

        /// <summary>
        /// Converts a number from base 10 to any base.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="toBase">To base.</param>
        /// <returns></returns>
        private byte[] ConvertToBase(int value, int toBase) {
            ValidateBase(toBase);
            byte[] bytes = new byte[8];
            int divisionResult = value;
            int remainder;
            for(int i = 0; divisionResult > 0; i++) {
                if (i == bytes.Length) bytes = ResizeArray(bytes);
                remainder = divisionResult  % toBase;
                bytes[i] = (byte)remainder;
                divisionResult = (divisionResult - remainder) / toBase;
            }
            return bytes;
        }

        private static byte[] ResizeArray(byte[] bytes) {
            int baseSize = 8;
            Array.Resize(ref bytes, bytes.Length + baseSize);
            return bytes;
        }

        private static void ValidateBase(int toBase) {
            if (toBase < 2) throw new ArgumentException("Invalid base.");
        }

        /// <summary>
        /// Converts a number from any base to base 10.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="fromBase">From base.</param>
        /// <returns></returns>
        private int ConvertFromBase(byte[] value, int fromBase) {
            int result = 0;
            for(int i = 0; i < value.Length; i++) {
                byte cellValue = value[i];
                result += cellValue * (int)Math.Pow(fromBase, i);
            }
            return result;
        }

        private static byte[] GetLargerArray(byte[] first, byte[] second) {
           return (first.Length > second.Length) ? first: second;
        }
    }
}
