﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class StringReverseReplace
    {
        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReverseString_StringIsEmpty_ReturnsEmptyString()
        {
            string value = string.Empty;

            string actual = ReverseString(value);

            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReverseString_StringHasOneCharacter_ReturnsSameString()
        {
            string value = "a";

            string actual = ReverseString(value);

            Assert.AreEqual("a", actual);
        }

        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReverseString_StringHasMoreCharacters_ReturnsReversedString()
        {
            string value = "abc";

            string actual = ReverseString(value);

            Assert.AreEqual("cba", actual);
        }

        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReplaceInString_StringIsEmpty_ReturnsEmptyString()
        {
            string value = string.Empty;

            string actual = ReplaceInString(value, 'i', "ai");

            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReplaceInString_SearchedCharacterIsFound_ReturnsModifiedString() {
            string value = "abcabcabcabcabc";

            string actual = ReplaceInString(value, 'b', "###");

            Assert.AreEqual("a###ca###ca###ca###ca###c", actual);
        }
        
        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReplaceInString_SearchedCharacterIsNotFound_ReturnsString() {
            string value = "abcabcabcabcabc";

            string actual = ReplaceInString(value, 'd', "###");

            Assert.AreEqual("abcabcabcabcabc", actual);
        }

        [TestMethod]
        [TestCategory("15_String_Reverse_And_Replace")]
        public void ReplaceInString_ReplaceStringIsEmpty_ReturnsString() {
            string value = "abcabcabcabcabc";

            string actual = ReplaceInString(value, 'b', string.Empty);

            Assert.AreEqual("abcabcabcabcabc", actual);
        }

        private string ReplaceInString(string value, char ch, string insertion)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            if (string.IsNullOrEmpty(insertion)) {
                return value;
            }

            char car = value[0];
            string cdr = value.Substring(1);
            if (car == ch) return insertion + ReplaceInString(cdr, ch, insertion);
            return car + ReplaceInString(cdr, ch, insertion);
        }

        private string ReverseString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            if (value.Length == 1)
            {
                return value;
            }

            char car = value[0];
            string cdr = value.Substring(1);
            return ReverseString(cdr) + car;
        }
    }
}
