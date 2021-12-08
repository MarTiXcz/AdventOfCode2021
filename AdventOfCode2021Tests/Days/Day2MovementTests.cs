using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2021.Days.Day2Movement;
using AdventOfCode2021.Utils;

namespace AdventOfCode2021.Days.Tests
{
    [TestClass()]
    public class Day2MovementTests
    {
        [DataTestMethod()]
        [DataRow("forward 5", Direction.Forward, 5)]
        public void ReadMoveTest(string moveString, Direction direction, int delta)
        {
            var move = ReadMove(moveString);
            Assert.AreEqual(direction, move.Direction);
            Assert.AreEqual(delta, move.Delta);
        }

        [TestMethod()]
        public void CalculatePositionTest()
        {
            var lines = InputReader.ReadLinesFromFilename("TestInput/test2.txt");
            var position = CalculatePosition(lines);
            Assert.AreEqual(150, position);
        }

        [TestMethod()]
        public void CalculateCorrectedPositionTest()
        {
            var lines = InputReader.ReadLinesFromFilename("TestInput/test2.txt");
            var position = CalculateCorrectedPosition(lines);
            Assert.AreEqual(900, position);
        }
    }
}