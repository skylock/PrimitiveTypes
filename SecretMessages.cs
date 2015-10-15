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
            char [,] expectedMessage = new char [,]
            {
                {'n', 'e', 'e', 'a'},
                {'i', 'r', 'c', 's'},
                {'c', 'i', 'a', 'a'},
                {'a', 'n', 'a', 'j'},
                {'i', 'u', 'c', 'w'}
            };

            char[,] actualMessage = EncryptMessage(message, key);

            CollectionAssert.AreEqual(expectedMessage, actualMessage);
        }

        private char[,] EncryptMessage(string message, int columns) {
            Random rgen = new Random(7);
            int rows = message.Length / columns;
            string cleanedString = CleanString(message);
            char[,] encryptedMessage = new char[rows, columns];
            int charIndex = 0;
            for (int i = 0; i < columns; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    if (charIndex < cleanedString.Length) {
                        encryptedMessage[j, i] = cleanedString[charIndex];
                    } 
                    else {
                        char ch = GetRandomChar(rgen);
                        encryptedMessage[j, i] = ch;
                    }
                    charIndex++;
                }
            }
            return encryptedMessage;
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
