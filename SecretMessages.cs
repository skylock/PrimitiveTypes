using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            string [,] expectedMessage = new string [,]
            {
                {"n", "e", "e", "a"},
                {"i", "r", "c", "s"},
                {"c", "i", "a", "a"},
                {"a", "n", "a", "x"},
                {"i", "u", "c", "w"}
            };

            string actualMessage = EncryptMessage(message, key);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        private string EncryptMessage(string message, int columns) {
            int rows = message.Length / columns;
            char[,] encryptedMessage = new char[rows, columns];
            int charIndex = 0;
            for (int i = 0; i < columns; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    char ch = message[charIndex];
                    encryptedMessage[j, i] = ch;
                    charIndex++;
                }
            }
            return string.Empty;
        }
    }
}
