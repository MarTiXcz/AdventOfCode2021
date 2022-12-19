using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Utils.Tests
{
    [TestClass()]
    public class InputReaderTests
    {
        [TestMethod()]
        public void ReadLinesFromFilenameTest()
        {
            var firstLine = InputReader.ReadLinesForDay(1).First();
            Assert.AreEqual("199", firstLine);
        }
    }
}