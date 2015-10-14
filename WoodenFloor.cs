using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class WoodenFloor
    {
        public bool lossesExist = false;

        [TestMethod]
        [TestCategory("10_Wooden_Floor")]
        public void Compute_Boards_Needed_When_Ll_Input_Values_Are_Zero()
        {

            Size boardSize = new Size(0, 0);
            Size roomSize = new Size(0, 0);
            uint lossesPercentage = 0;

            uint neededBoards = ComputeNeededBoards(roomSize, boardSize, lossesPercentage);

            Assert.AreEqual<uint>(0, neededBoards);
        }

        [TestMethod]
        [TestCategory("10_Wooden_Floor")]
        public void Compute_Boards_Needed_When_Losses_Percentage_Is_Zero()
        {

            Size boardSize = new Size(300, 700);
            Size roomSize = new Size(3000, 7000);
            uint lossesPercentage = 0;

            uint neededBoards = ComputeNeededBoards(roomSize, boardSize, lossesPercentage);

            Assert.AreEqual<uint>(100, neededBoards);
        }

        [TestMethod]
        [TestCategory("10_Wooden_Floor")]
        public void Compute_Boards_Needed_When_BoardSide_Length_Or_Width_Is_Zero()
        {

            Size boardSize = new Size(0, 10);
            Size roomSize = new Size(3000, 7000);
            uint lossesPercentage = 15;

            uint neededBoards = ComputeNeededBoards(roomSize, boardSize, lossesPercentage);

            Assert.AreEqual<uint>(0, neededBoards);
        }

        [TestMethod]
        [TestCategory("10_Wooden_Floor")]
        public void Compute_Boards_Needed_When_RoomSide_Length_Or_Width_Is_Zero()
        {

            Size boardSize = new Size(300, 700);
            Size roomSize = new Size(0, 7000);
            uint lossesPercentage = 15;

            uint neededBoards = ComputeNeededBoards(roomSize, boardSize, lossesPercentage);

            Assert.AreEqual<uint>(0, neededBoards);
        }

        [TestMethod]
        [TestCategory("10_Wooden_Floor")]
        public void Compute_Boards_Needed_When_BoardSide_Length_Or_Width_Is_Smaller_ThanRoom_Size()
        {

            Size boardSize = new Size(300, 700);
            Size roomSize = new Size(30, 70);
            uint lossesPercentage = 15;

            uint neededBoards = ComputeNeededBoards(roomSize, boardSize, lossesPercentage);

            Assert.AreEqual<uint>(1, neededBoards);
        }

        [TestMethod]
        [TestCategory("10_Wooden_Floor")]
        public void Compute_Boards_Needed_When_BoardSide_Is_Exact_Multiple_For_Floor_Length_Or_Width() {

            Size boardSize = new Size(300,700);
            Size roomSize = new Size(3000, 7000);
            uint lossesPercentage = 15;

            uint neededBoards = ComputeNeededBoards(roomSize, boardSize, lossesPercentage);

            Assert.AreEqual<uint>(100, neededBoards);
        }

        [TestMethod]
        [TestCategory("10_Wooden_Floor")]
        public void Compute_Boards_Needed_When_BoardSide_Is_Not_Exact_Multiple_For_Floor_Length_Or_Width() {

            Size boardSize = new Size(300, 700);
            Size roomSize = new Size(3100, 7100);
            uint lossesPercentage = 15;

            uint neededBoards = ComputeNeededBoards(roomSize, boardSize, lossesPercentage);

            Assert.AreEqual<uint>(139, neededBoards);
        }


        private uint ComputeNeededBoards(Size roomSize, Size boardSize, uint lossesPercentage) {
            uint boards = GetNeededBoards(roomSize, boardSize);
            uint boardsToCoverLosses = GetLosses(boards, lossesPercentage);
            return boards + boardsToCoverLosses;
        }

        private uint GetLosses(uint boards, uint lossesPercentage) {
            if (!lossesExist) return 0;
            return (uint)(boards * (lossesPercentage / 100.0));
        }

        private uint GetNeededBoards(Size roomSize, Size boardSize)
        {
            uint boardsOnWidth = GetNeededBoardsOnSide(roomSize.length, boardSize.length);
            uint boardsOnLength = GetNeededBoardsOnSide(roomSize.width, boardSize.width);
            return boardsOnWidth * boardsOnLength;

        }

        private uint GetNeededBoardsOnSide(uint sideSize, uint boardSide) {
            if (sideSize < boardSide && sideSize > 0) {
                return 1;
            } else {
                if (sideSize == 0) {
                    return 0;
                } else if (boardSide > 0) {
                    if (sideSize % boardSide == 0) {
                        return sideSize / boardSide;
                    } else {
                        lossesExist = true;
                        return (sideSize / boardSide) + 1;
                    }
                } else {
                    return 0;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct Size 
    {
        /// <summary>
        /// The board length
        /// </summary>
        public uint length, width;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> struct.
        /// </summary>
        /// <param name="length">form length in milimeters.</param>
        /// <param name="width">Form width in milimeters.</param>
        public Size(uint length, uint width)
        {
            this.length = length;
            this.width = width;
        }
    }
}
