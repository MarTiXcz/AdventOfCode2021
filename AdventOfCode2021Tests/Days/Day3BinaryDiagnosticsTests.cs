using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Utils;

namespace AdventOfCode2021.Days.Tests
{
    [TestClass()]
    public class Day3BinaryDiagnosticsTests
    {
        [TestMethod()]
        public void CalculateConsumptionTest()
        {
            var lines = InputReader.ReadLinesFromFilename("TestInput/test3.txt");
            var consumption = Day3BinaryDiagnostics.CalculateConsumption(lines);
            Assert.AreEqual(198, consumption);
        }

        [TestMethod()]
        public void CalculateLifeSupportTest()
        {
            var lines = InputReader.ReadLinesFromFilename("TestInput/test3.txt");
            var lifeSupport = Day3BinaryDiagnostics.CalculateLifeSupport(lines);
            Assert.AreEqual(230, lifeSupport);
        }
    }
}