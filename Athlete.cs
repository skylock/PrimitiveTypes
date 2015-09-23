using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class Athlete
    {
        [TestMethod]
        [TestCategory("06_Athlete")]
        public void Compute_Exercises_For_Zero_Repetitions() {
            int repetitions = 0;

            int exercises = GetExercisesCount(repetitions);

            Assert.AreEqual(0, exercises);
        }

        [TestMethod]
        [TestCategory("06_Athlete")]
        public void Compute_Exercises_For_One_Repetitions() {
            int repetitions = 1;

            int exercises = GetExercisesCount(repetitions);

            Assert.AreEqual(1, exercises);
        }

        [TestMethod]
        [TestCategory("06_Athlete")]
        public void Compute_Exercises_For_3_Repetitions() {
            int repetitions = 3 ;

            int exercises = GetExercisesCount(repetitions);

            Assert.AreEqual(9, exercises);
        }

        [TestMethod]
        [TestCategory("06_Athlete")]
        public void Compute_Exercises_For_10_Repetitions() {
            int repetitions = 10;

            int exercises = GetExercisesCount(repetitions);

            Assert.AreEqual(100, exercises);
        }

        private int GetExercisesCount(int repetitions) {
            if (repetitions > 0) {
                return repetitions * repetitions;
            } else {
                return 0;
            }
        }
    }
}
