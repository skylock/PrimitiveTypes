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
            string expected = "neeaircsciaaanaxiucw";
            string actual = EncryptMessage(message, key);

            Assert.AreEqual(expected, actual);
        }

        private string EncryptMessage(string message, int key) {
            throw new NotImplementedException();
        }
    }
}
