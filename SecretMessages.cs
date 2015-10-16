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
            Random rgen = new Random(7);
            char[] cleanStr = CleanString(message).ToCharArray();
            int rows = (int)Math.Ceiling((double)cleanStr.Length / columns);
            char[] encryptedMessage = new char[rows * columns];
            int startIndex = 0;
            int iterator = 0;
            while (iterator < cleanStr.Length) {
                for (int i = startIndex; i < encryptedMessage.Length; i += columns) {
                    char value = iterator >= cleanStr.Length ? GetRandomChar(rgen) : cleanStr[iterator];
                    encryptedMessage[i] = value;
                    iterator++;
                }
                startIndex++;
            }
            string result = new string(encryptedMessage);
            return result;
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