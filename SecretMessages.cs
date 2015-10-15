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
            int rows = message.Length / columns;
            char[] cleanedString = CleanString(message).ToCharArray();
            char[] encryptedMessage = new char[rows * columns];
            for (int i = 0; i < encryptedMessage.Length; i++) {
                if (i * rows < cleanedString.Length) {
                    encryptedMessage[i] = cleanedString[i * rows];
                }
            }
            return string.Empty;
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
