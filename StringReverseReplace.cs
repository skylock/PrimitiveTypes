using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class StringReverseReplace
    {
        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReverseString_StringIsEmpty_ReturnsEmptyString() {
            string value = string.Empty;

            string actual = ReverseString(value);

            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReverseString_StringHasOneCharacter_ReturnsSameString() {
            string value = "a";

            string actual = ReverseString(value);

            Assert.AreEqual("a", actual);
        }

        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReverseString_StringHasMoreCharacters_ReturnsReversedString() {
            string value = "abc";

            string actual = ReverseString(value);

            Assert.AreEqual("cba", actual);
        }

        private string ReverseString(string value) {
            if (string.IsNullOrEmpty(value)) {
                return value;
            }

            if (value.Length == 1) {
                return value;
            }

            char car = value[0];
            string cdr = value.Substring(1);
            return ReverseString(cdr) + car;
        }
    }
}
