using AdventOfCode2021.Core;
using AdventOfCode2021.Utils;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeBenchmark
{
    [MemoryDiagnoser]
    public class Day3Benchmark
    {
        [Benchmark]
        public void DiagnosticsNaiveSpan() {
            var submarine = new Submarine();
            submarine.ImportDiagnosticsNaiveAsSpan(InputReader.ReadLinesForDay(3));
        }
        [Benchmark]
        public void DiagnosticsNaive()
        {
            var submarine = new Submarine();
            submarine.ImportDiagnosticsNaive(InputReader.ReadLinesForDay(3));
        }
    }
}
