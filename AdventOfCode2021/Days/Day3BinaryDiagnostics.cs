using AdventOfCode2021.Core;
using AdventOfCode2021.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days
{
    public class Day3BinaryDiagnostics
    {
        public static void Run()
        {
            try
            {
                var input = InputReader.ReadLines(day: 3);
                int consumption = CalculateConsumption(input);
                Console.WriteLine($"The power consumption is: {consumption}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to read file. Reason: {ex.Message}");
            }
        }

        public static int CalculateConsumption(IEnumerable<string> input)
        {
            Submarine submarine = new();
            submarine.ImportDiagnosticsNaive(input);
            return submarine.PowerConsumption;
        }
    }
}
