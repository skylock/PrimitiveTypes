using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class Loto
    {
        [TestMethod]
        [TestCategory("11_Loto_Chances")]
        public void Get_Winning_Chances_For_First_Category() {
            byte category = 1;
            double expectedChances = 1 / 13983816;

            double actualChances = GetWinningChances(category);

            Assert.AreEqual(expectedChances, actualChances);
        }

        [TestMethod]
        [TestCategory("11_Loto_Chances")]
        public void Get_Winning_Chances_For_Second_Category() {
            byte category = 2;
            double expectedChances = 1 / 54021;

            double actualChances = GetWinningChances(category);

            Assert.AreEqual(expectedChances, actualChances);
        }

        [TestMethod]
        [TestCategory("11_Loto_Chances")]
        public void Get_Winning_Chances_For_Third_Category() {
            byte category = 3;
            double expectedChances = 1 / 1032;

            double actualChances = GetWinningChances(category);

            Assert.AreEqual(expectedChances, actualChances);
        }

        [TestMethod]
        [TestCategory("11_Loto_Chances")]
        public void Compute_Combinations_Of_6_From_A_Set_Of_49_Equals_() {
            Assert.AreEqual<ulong>(13983816, GetCombinations(49, 6));
        }

        [TestMethod]
        [TestCategory("11_Loto_Chances")]
        public void Compute_Combinations_Of_49_From_A_Set_Of_6_Equals_() {
            Assert.AreEqual<ulong>(0, GetCombinations(6, 49));
        }

        [TestMethod]
        [TestCategory("11_Loto_Chances")]
        public void Factorial_10_Equals_3628800() {
            Assert.AreEqual<ulong>(3628800, Factorial(10));
        }

        [TestMethod]
        [TestCategory("11_Loto_Chances")]
        public void Factorial_0_Equals_1() {
            Assert.AreEqual<ulong>(1, Factorial(0));
        }

        /// <summary>
        /// Gets the winning chances.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        private double GetWinningChances(byte category) {
            ulong favorableCases = 0;
            switch (category) {
                case 1:
                    favorableCases = GetCombinations(6, 6) * GetCombinations(43, 0);
                    break;
                case 2:
                    favorableCases = GetCombinations(6, 5) * GetCombinations(43, 1);
                    break;
                default:
                    favorableCases = GetCombinations(6, 4) * GetCombinations(43, 2);
                    break;
            }
            ulong posibleCases = GetCombinations(49,6);
            return (double)(favorableCases / posibleCases);
        }

        /// <summary>
        /// Gets the combinations using formula [n(n-1)(n-2)...(n-k-1) / k!].
        /// </summary>
        /// <param name="n">The n objects.</param>
        /// <param name="k">The k objects taken into account for combinations.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Number of possible combinations of k objects must be bigger than the set of n objects</exception>
        private ulong GetCombinations(ulong n, ulong k)
        {
            if (n < k) return 0;
            return  MultiplyConsecutiveNumbers(n,n-k) / Factorial(k);
        }

        /// <summary>
        /// Factorials the specified n.
        /// </summary>
        /// <param name="n">Number to compute factorial function.</param>
        /// <returns></returns>
        private ulong Factorial(ulong n)
        {
            return MultiplyConsecutiveNumbers(n, 0);
        }

        /// <summary>
        /// Multiplies the consecutive numbers.
        /// </summary>
        /// <param name="n">Starting number n.</param>
        /// <param name="floorLimit">Number where multiplication should stop. Must be less than the starting number.</param>
        /// <returns></returns>
        private ulong MultiplyConsecutiveNumbers(ulong n, ulong floorLimit) {
            ulong p = 1;
            for (ulong i = n; i > floorLimit; i--) {
                p *= i;
            }
            return p;
        }
    }
}
