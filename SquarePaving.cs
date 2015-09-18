using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class SquarePaving
    {
        [TestMethod]
        [TestCategory("01_SquarePaving")]
        public void Compute_Bricks_Needed_When_BrickSide_Is_Bigger_Than_Field_Length_Or_With() {
            int fieldLength = 3;
            int fieldWidth = 6;
            int brickSideLengh = 8;
            int expectedResult = 1;

            int result = ComputeNeededBricks(fieldLength, fieldWidth, brickSideLengh);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [TestCategory("01_SquarePaving")]
        public void Compute_Bricks_Needed_When_BrickSide_Is_Bigger_Than_Field_Length() {
            int fieldLength = 3;
            int fieldWidth = 6;
            int brickSideLengh = 4;
            int expectedResult = 2;

            int result = ComputeNeededBricks(fieldLength, fieldWidth, brickSideLengh);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [TestCategory("01_SquarePaving")]
        public void Compute_Bricks_Needed_When_BrickSide_Is_Smaller_Than_Field_Length_Or_Width() {
            int fieldLength = 6;
            int fieldWidth = 6;
            int brickSideLengh = 4;
            int expectedResult = 4;

            int result = ComputeNeededBricks(fieldLength, fieldWidth, brickSideLengh);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [TestCategory("01_SquarePaving")]
        public void Compute_Bricks_Needed_When_BrickSide_Is_Exact_Multiple_For_Field_Length_Or_Width() {
            int fieldLength = 8;
            int fieldWidth = 8;
            int brickSideLengh = 2;
            int expectedResult = 16;

            int result = ComputeNeededBricks(fieldLength, fieldWidth, brickSideLengh);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [TestCategory("01_SquarePaving")]
        public void Compute_Bricks_Needed_When_BrickSide_Is_Zero() {
            int fieldLength = 3;
            int fieldWidth = 6;
            int brickSideLengh = 0;
            int expectedResult = 0;

            int result = ComputeNeededBricks(fieldLength, fieldWidth, brickSideLengh);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [TestCategory("01_SquarePaving")]
        public void Compute_Bricks_Needed_When_FieldLength_Is_Zero() {
            int fieldLength = 0;
            int fieldWidth = 6;
            int brickSideLengh = 4;
            int expectedResult = 0;

            int result = ComputeNeededBricks(fieldLength, fieldWidth, brickSideLengh);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [TestCategory("01_SquarePaving")]
        public void Compute_Bricks_Needed_When_FieldWidth_Is_Zero() {
            int fieldLength = 0;
            int fieldWidth = 0;
            int brickSideLengh = 4;
            int expectedResult = 0;

            int result = ComputeNeededBricks(fieldLength, fieldWidth, brickSideLengh);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [TestCategory("01_SquarePaving")]
        public void Compute_Bricks_Needed_When_All_Input_Values_Are_Zero() {
            int fieldLength = 0;
            int fieldWidth = 0;
            int brickSideLengh = 0;
            int expectedResult = 0;

            int result = ComputeNeededBricks(fieldLength, fieldWidth, brickSideLengh);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [TestCategory("01_SquarePaving")]
        public void Compute_Bricks_Needed_When_All_Input_Values_Are_Negative() {
            int fieldLength = -1;
            int fieldWidth = -1;
            int brickSideLengh = -1;
            int expectedResult = 0;

            int result = ComputeNeededBricks(fieldLength, fieldWidth, brickSideLengh);

            Assert.AreEqual(expectedResult, result);
        }

        private int ComputeNeededBricks(int fieldLength, int fieldWidth, int brickSideLengh) {
            int briksOnLength = ComputeBricksOnSide(fieldLength,brickSideLengh);
            int bricksOnWith = ComputeBricksOnSide(fieldWidth, brickSideLengh);
            return briksOnLength * bricksOnWith;
        }

        private static int ComputeBricksOnSide(int sideSize, int brickSideSize) {
            if (sideSize < brickSideSize && sideSize > 0) {
                return 1;
            } else {
                if (sideSize == 0) {
                    return 0;
                } else if (brickSideSize > 0) {
                    if (sideSize % brickSideSize == 0) {
                        return sideSize / brickSideSize;
                    } else {
                        return (sideSize / brickSideSize) + 1;
                    }
                } else {
                    return 0;
                }
            }
        }
    }
}
