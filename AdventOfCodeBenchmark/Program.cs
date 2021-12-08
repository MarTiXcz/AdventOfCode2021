// See https://aka.ms/new-console-template for more information
using AdventOfCode2021;
using AdventOfCode2021.Utils;
using AdventOfCodeBenchmark;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;




var day1Summary = BenchmarkRunner.Run<Day1Benchmark>();
try
{
    if (!Directory.Exists("./Results"))
    {
        Directory.CreateDirectory("./Results");
    }
    File.WriteAllText("Results/day1.txt", day1Summary.ToString());
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.ToString());
}