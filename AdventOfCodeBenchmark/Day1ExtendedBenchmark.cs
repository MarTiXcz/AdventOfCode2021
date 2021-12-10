using AdventOfCode2021;
using AdventOfCode2021.Days;
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
    //[SimpleJob(launchCount: 3, warmupCount: 2, targetCount: 10)]
    public class Day1ExtendedBenchmark
    {
        [Benchmark]
        public int CountSumIncreasesWithSelectEnumerated()
        {
            return Day1SonarSweep.CountSumIncreasesWithSelectEnumerated(InputReader.ReadLines(1));
        }

        [Benchmark]
        public int CountSumIncreasesWithSelectCleverEnumerated()
        {
            return Day1SonarSweep.CountSumIncreasesWithSelectCleverEnumerated(InputReader.ReadLines(1));
        }
    }
}
