using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Utils;

namespace AdventOfCode2021.Tests
{
    [TestClass()]
    public class Day1SonarSweepTests
    {
        private static IEnumerable<string> Lines { get; } = InputReader.ReadLinesFromFilename("TestInput/test1.txt");
        private Day1SonarSweep SonarSweep { get; }
        public Day1SonarSweepTests()
        {
            SonarSweep = new Day1SonarSweep();
        }

        [TestMethod()]
        public void CountIncreasesTest()
        {
            var count = Day1SonarSweep.CountIncreases(Lines);
            Assert.AreEqual(7, count);
        }

        [TestMethod()]
        public void CountIncreasesAsStringTest()
        {
            var count = Day1SonarSweep.CountIncreasesAsString(Lines);
            Assert.AreEqual(7, count);
        }

        [TestMethod()]
        public void CountIncreasesOldSchoolTest()
        {
            var count = Day1SonarSweep.CountIncreasesOldSchool(Lines);
            Assert.AreEqual(7, count);
        }

        [DataTestMethod()]
        [DataRow(new string[] { }, 0)]
        [DataRow(new string[] { "1" }, 0)]
        [DataRow(new string[] { "1", "2" }, 1)]
        public void CountIncreasesOldSchoolTestEdgeCase(IEnumerable<string> lines, int expectedResult)
        {
            var count = Day1SonarSweep.CountIncreasesOldSchool(lines);
            Assert.AreEqual(expectedResult, count);
        }

        [TestMethod()]
        public void CountIncreasesWithSelectForTest()
        {
            var count = Day1SonarSweep.CountIncreasesWithSelectFor(Lines);
            Assert.AreEqual(7, count);
        }

        [TestMethod()]
        public void CountSumIncreasesWithSelectEnumeratedTest()
        {
            var count = Day1SonarSweep.CountSumIncreasesWithSelectEnumerated(Lines);
            Assert.AreEqual(5, count);
        }

        [TestMethod()]
        public void CountSumIncreasesWithSelectCleverEnumerated()
        {
            var count = Day1SonarSweep.CountSumIncreasesWithSelectCleverEnumerated(Lines);
            Assert.AreEqual(5, count);
        }

    }
}