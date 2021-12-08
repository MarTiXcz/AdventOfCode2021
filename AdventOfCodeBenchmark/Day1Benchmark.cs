using AdventOfCode2021;
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
    public class Day1Benchmark
    {
        [Benchmark]
        public int CountIncreases()
        {
            return Day1SonarSweep.CountIncreases(InputReader.ReadLines(1));
        }
        [Benchmark]
        public int CountIncreasesWithSelect()
        {
            return Day1SonarSweep.CountIncreasesWithSelect(InputReader.ReadLines(1));
        }

        [Benchmark]
        public int CountIncreasesWithSelectEnumerated()
        {
            return Day1SonarSweep.CountIncreasesWithSelect(InputReader.ReadLines(1));
        }
        [Benchmark]
        public int CountIncreasesWithSelectFor()
        {
            return Day1SonarSweep.CountIncreasesWithSelectFor(InputReader.ReadLines(1));
        }
        [Benchmark]
        public int CountIncreasesAsString()
        {
            return Day1SonarSweep.CountIncreasesAsString(InputReader.ReadLines(1));
        }

        [Benchmark]
        public int CountIncreasesOldSchool()
        {
            return Day1SonarSweep.CountIncreasesOldSchool(InputReader.ReadLines(1));
        }
    }
}
