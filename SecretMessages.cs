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
        [ExpectedException(typeof(ArgumentException))]
        public void Encrypt_Message_When_Key_0() {
            uint key = 0;
            string message = "nicaieri nu e ca acasa";

            string actualMessage = EncryptMessage(message, key);
        }

        [TestMethod]
        [TestCategory("12_Secret_Messages")]
        [ExpectedException(typeof(ArgumentException))]
        public void Encrypt_Message_When_Key_1() {
            uint key = 1;
            string message = "nicaieri nu e ca acasa";

            string actualMessage = EncryptMessage(message, key);
        }

        [TestMethod]
        [TestCategory("12_Secret_Messages")]
        public void Encrypt_Message_When_Key_2() {
            uint key = 2;
            string message = "nicaieri nu e ca acasa";
            string expectedMessage = "nuieccaaiaecraisna";

            string actualMessage = EncryptMessage(message, key);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        [TestCategory("12_Secret_Messages")]
        public void Decrypt_Message_When_Key_2() {
            uint key = 2;
            string message = "nuieccaaiaecraisna";
            string expectedMessage = "nicaierinuecaacasa";

            string actualMessage = DecryptMessage(message, key);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        [TestCategory("12_Secret_Messages")]
        public void Encrypt_Message_When_Key_4() {
            uint key = 4;
            string message = "nicaieri nu e ca acasa";
            string expectedMessage = "neeaircsciaaanajiucw";

            string actualMessage = EncryptMessage(message, key);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        [TestCategory("12_Secret_Messages")]
        public void Decrypt_Message_When_Key_4() {
            uint key = 4;
            string message = "neeaircsciaaanajiucw";
            string expectedMessage = "nicaierinuecaacasajw";

            string actualMessage = DecryptMessage(message, key);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        [TestCategory("12_Secret_Messages")]
        public void Encrypt_Message_When_Key_5() {
            uint key = 5;
            string message = "nicaieri nu e ca acasa";
            string expectedMessage = "ninasieuaacrecjaicaw";

            string actualMessage = EncryptMessage(message, key);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        [TestCategory("12_Secret_Messages")]
        public void Encrypt_Message_When_Key_Is_On_Char_Less_Than_Message() {
            uint key = 17;
            string message = "nicaieri nu e ca acasa";
            string expectedMessage = "ncirneacsjrjbvllwiaeiucaaawbrywyck";

            string actualMessage = EncryptMessage(message, key);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        private string DecryptMessage(string message, uint columns) {
            uint rows = (uint)message.Length / columns;
            return EncryptMessage(message, rows);
        }

        private string EncryptMessage(string message, uint columns) {
            Random generator = new Random(7);
            string cleanStr = CleanString(message);
            ValidateInput(cleanStr, columns);
            int strLength = GetStrLength(columns, cleanStr);
            char[] encryptedMessage = new char[strLength];
            uint startIndex = 0;
            int currentIndex = 0;
            while (currentIndex < encryptedMessage.Length) {
                for (uint i = startIndex; i < encryptedMessage.Length; i += columns) {
                    encryptedMessage[i] = GetCharValue(cleanStr, currentIndex, generator);
                    currentIndex++;
                }
                startIndex++;
            }
            return new string(encryptedMessage);
        }

        private string CleanString(string message) {
            Regex regex = new Regex("[^a-zA-Z-]");
            return regex.Replace(message, "");
        }

        private char GetCharValue(string cleanStr, int index, Random generator) {
            return index >= cleanStr.Length ? GetRandomChar(generator) : cleanStr[index];
        }

        private char GetRandomChar(Random rgen) {
            int rChar = rgen.Next(0, 26);
            return (char)('a' + rChar);
        }

        private static int GetStrLength(uint columns, string input) {
            int rows = (int)Math.Ceiling((double)input.Length / columns);
            return (int)(rows * columns);
        }

        private static void ValidateInput(string message, uint columns) {
            if (columns < 2 || columns >= message.Length) {
                string exceptionMessage = string.Format("Columns parameter must be grater than zero and less than {0}.", message.Length);
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}