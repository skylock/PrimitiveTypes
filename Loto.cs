using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class Loto
    {
        //[TestMethod]
        //[TestCategory("11_Loto_Chances")]
        //public void Get_Winning_Chances_For_First_Chategory()
        //{
        //    ulong category = 1;
        //    double expectedChances = 1 / 13983816;

        //    double actualChances = GetWinningChances(category);

        //    Assert.AreEqual(expectedChances, actualChances);
        //}
        [TestMethod]
        [TestCategory("11_Loto_Chances")]
        public void Combinations_6_From_Set_Of_49_Equals_()
        {
            Assert.AreEqual<ulong>(13983816, GetCombinations(49,6));
        }

        [TestMethod]
        [TestCategory("11_Loto_Chances")]
        public void Factorial_10_Equals_3628800()
        {
            Assert.AreEqual<ulong>(3628800, Factorial(10));
        }

        [TestMethod]
        [TestCategory("11_Loto_Chances")]

        public void Factorial_0_Equals_1()
        {
            Assert.AreEqual<ulong>(1, Factorial(0));
        }

        //private double GetWinningChances(ulong category)
        //{
        //    ulong posibleCases = GetCombinations(6, 49);
        //    return (double)(1 / posibleCases);
        //}

        private ulong GetCombinations(ulong n, ulong k)
        {
            if (n > k)
            {
                ulong factN = Factorial(n);
                ulong factK = Factorial(k);
                ulong factNK = Factorial(n - k);
                ulong result = factN / factK * factNK;
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
            }

            throw new ArgumentException("Number of possible combinations of k objects must be bigger than the set of n objects");
        }

        private ulong Factorial(ulong n)
        {
            ulong p = 1;
            for(ulong i=1; i <= n; i++)
            {
                p = p * i;
            }
            return p;
        }
    }
}
