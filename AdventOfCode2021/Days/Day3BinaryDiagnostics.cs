using AdventOfCode2021.Core;
using AdventOfCode2021.Utils;

namespace AdventOfCode2021.Days
{
    public sealed class Day3BinaryDiagnostics
    {
        public static void Run()
        {
            try
            {
                var input = InputReader.ReadLinesForDay(day: 3);
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
            submarine.ImportDiagnosticsNaiveAsSpan(input);
            return submarine.PowerConsumption;
        }

        public static int CalculateLifeSupport(IEnumerable<string> input)
        {
            Submarine submarine = new();
            submarine.ImportExtendedDiagnostics(input);
            return submarine.OxygenRating;
        }
    }
}
