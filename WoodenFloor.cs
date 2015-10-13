using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class WoodenFloor
    {
        [TestMethod]
        public void Compute_Boards_Needed_When_BoardSide_Is_Exact_Multiple_For_Floor_Length_Or_Width() {
            Tuple<uint, uint> boardSizeInMilimeters = new Tuple<uint, uint>(300, 700);
            Tuple<uint, uint> roomSizeInMilimeters = new Tuple<uint, uint>(3000, 7000);
            uint lossesPercentage = 15;

            double neededBoards = ComputeNeededBoards(roomSizeInMilimeters, boardSizeInMilimeters, lossesPercentage);

            Assert.AreEqual(115, neededBoards);
        }

        private uint ComputeNeededBoards(Tuple<uint, uint> roomSize, Tuple<uint, uint> boardSize, uint lossesPercentage) {
            uint boardsOnWidth = ComputeNeededBoardsOnSide(roomSize.Item1, boardSize.Item1);
            uint boardsOnLength = ComputeNeededBoardsOnSide(roomSize.Item2, boardSize.Item2);
            uint boards =  boardsOnWidth * boardsOnLength;
            return (uint)GetLosses(boards, lossesPercentage) + 1;
        }

        private double GetLosses(uint number, uint percent) {
            double percentage = percent / 100.0;
            return (double)number * (percentage + 1);
        }

        private static uint ComputeNeededBoardsOnSide(uint sideSize, uint boardSide) {
            if (sideSize < boardSide && sideSize > 0) {
                return 1;
            } else {
                if (sideSize == 0) {
                    return 0;
                } else if (boardSide > 0) {
                    if (sideSize % boardSide == 0) {
                        return sideSize / boardSide;
                    } else {
                        return (sideSize / boardSide) + 1;
                    }
                } else {
                    return 0;
                }
            }
        }
    }
}
