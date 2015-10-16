using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace PrimitiveTypes
{
    [TestClass]
    public class SecretMessages
    {
        [TestMethod]
        [TestCategory("12_Secret_Messages")]
        public void Test_Encription_When_Message_Is_Not_Empty() {
            int key = 4;
            string message = "nicaieri nu e ca acasa";
            string expectedMessage = "neeaircsciaaanajiucw";

            string actualMessage = EncryptMessage(message, key);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        private string EncryptMessage(string message, int columns) {
            string cleandStr = CleanString(message);
            int rows = GetRows(cleandStr, columns);
            int length = (rows * columns) - cleandStr.Length;
            string preparedStr = cleandStr + GetRandomStr(length);
            string [] matrix = CreateSubstrings(preparedStr, columns);
            string[] columnToRow = new string[rows];
            for (int i = 0; i <= columns; i++) {
                columnToRow[i] = ReadMatrixColumn(matrix, i);
            }
            string encryptedStr = string.Join("",columnToRow);
            return encryptedStr;
        }

        private string ReadMatrixColumn(string[] matrix, int column) {
            char[] result = new char[matrix.Length];
            for (int i = 0; i < matrix.Length; i++) {
                result[i] = matrix[i][column];
            }
            return new string(result);
        }

        private static int GetRows(string cleandStr, int columns) {
            int rows = (int)Math.Ceiling((double)cleandStr.Length / columns);
            return rows;
        }

        private string[] CreateSubstrings(string preparedStr, int size) {
            int rows = preparedStr.Length / size;
            string[] subStrings = new string[size];
            for (int i = 0; i < subStrings.Length; i++) {
                subStrings[i] = preparedStr.Substring(i * rows, rows);
            }
            return subStrings;
        }

        private string GetRandomStr(int length) {
            Random rgen = new Random(7);
            char[] randomStr = new char[length];
            for (int i = 0; i < randomStr.Length; i++ ) {
                randomStr[i] = GetRandomChar(rgen);
            }
            return new string(randomStr);
        }

        private char GetRandomChar(Random rgen) {
            int rChar = rgen.Next(0, 26);
            return (char)('a' + rChar);
        }

        private string CleanString(string message) {
            Regex rgx = new Regex("[^a-zA-Z-]");
            return rgx.Replace(message, "");
        }
    }
}
