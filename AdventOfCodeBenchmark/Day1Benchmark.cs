﻿using AdventOfCode2021;
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
    public class Day1Benchmark
    {
        [Benchmark]
        public int CountIncreases()
        {
            return Day1SonarSweep.CountIncreases(InputReader.ReadLinesForDay(1));
        }
        [Benchmark]
        public int CountIncreasesWithSelect()
        {
            return Day1SonarSweep.CountIncreasesWithSelect(InputReader.ReadLinesForDay(1));
        }

        [Benchmark]
        public int CountIncreasesWithSelectEnumerated()
        {
            return Day1SonarSweep.CountIncreasesWithSelectEnumerated(InputReader.ReadLinesForDay(1));
        }
        [Benchmark]
        public int CountIncreasesWithSelectFor()
        {
            return Day1SonarSweep.CountIncreasesWithSelectFor(InputReader.ReadLinesForDay(1));
        }
        [Benchmark]
        public int CountIncreasesWithSelectForSkipAny()
        {
            return Day1SonarSweep.CountIncreasesWithSelectForSkipAny(InputReader.ReadLinesForDay(1));
        }
        //Commented out it's slow
        // CountIncreasesWithSelectForElementAt | 1,448,091.7 us | 28,668.86 us | 53,139.58 us | 77000.0000 | 33000.0000 | 1000.0000 | 238,425 KB |
        //[Benchmark]
        //public int CountIncreasesWithSelectForElementAt()
        //{
        //    return Day1SonarSweep.CountIncreasesWithSelectForElementAt(InputReader.ReadLines(1));
        //}
        [Benchmark]
        public int CountIncreasesAsString()
        {
            return Day1SonarSweep.CountIncreasesAsString(InputReader.ReadLinesForDay(1));
        }

        [Benchmark]
        public int CountIncreasesOldSchool()
        {
            return Day1SonarSweep.CountIncreasesOldSchool(InputReader.ReadLinesForDay(1));
        }

        [Benchmark]
        public int CountIncreasesOldSchoolWithList()
        {
            return Day1SonarSweep.CountIncreasesOldSchoolWithList(InputReader.ReadLinesForDay(1));
        }
    }
}
