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
            char[] cleanStr = CleanString(message).ToCharArray();
            ValidateInput(cleanStr.Length, columns);
            Random rgen = new Random(7);
            int rows = (int)Math.Ceiling((double)cleanStr.Length / columns);
            char[] encryptedMessage = new char[rows * columns];
            uint startIndex = 0;
            int iterator = 0;
            while (iterator < rows * columns) {
                for (uint i = startIndex; i < encryptedMessage.Length; i += columns) {
                    char value = iterator >= cleanStr.Length ? GetRandomChar(rgen) : cleanStr[iterator];
                    encryptedMessage[i] = value;
                    iterator++;
                }
                startIndex++;
            }
            string result = new string(encryptedMessage);
            return result;
        }

        private static void ValidateInput(int messageLength, uint columns) {
            if (columns < 2 || columns >= messageLength) {
                string exceptionMessage = string.Format("Columns parameter must be grater than zero and less than {0}.", messageLength);
                throw new ArgumentException(exceptionMessage);
            }
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