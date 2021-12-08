using AdventOfCode2021.Utils;

namespace AdventOfCode2021
{
    public class Day1SonarSweep
    {
        public static void Run()
        {
            try
            {
                var input = InputReader.ReadLines(day: 1);
                CountIncreases(input);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to read file. Reason: {ex.Message}");
            }
        }

        //first idea
        public static int CountIncreases(IEnumerable<string> numbers)
        {
            if (!numbers.Any())
            {
                return 0;
            }

            int count = 0;
            int previousNumber = numbers.First().ToInt();

            foreach (var line in numbers.Skip(1))
            {
                var number = line.ToInt();
                if (number > previousNumber)
                {
                    count++;
                }
                previousNumber = number;
            }
            return count;
        }

        public static int CountIncreasesWithSelect(IEnumerable<string> numbers)
        {
            return CountIncreasesWithSelect(numbers.Select(n => n.ToInt()));
        }
        public static int CountIncreasesWithSelectEnumarated(IEnumerable<string> numbers)
        {
            return CountIncreasesWithSelect(numbers.Select(n => n.ToInt()).ToList());
        }

        public static int CountIncreasesWithSelect(IEnumerable<int> numbers)
        {
            if (!numbers.Any())
            {
                return 0;
            }
            int count = 0;
            int previousNumber = numbers.First();
            foreach (var number in numbers.Skip(1))
            {
                if (number > previousNumber)
                {
                    count++;
                }
                previousNumber = number;
            }
            return count;
        }

        public static int CountIncreasesWithSelectFor(IEnumerable<string> numbers)
        {
            if (!numbers.Any())
            {
                return 0;
            }
            int count = 0;
            var intNumbers = numbers.Select(n => n.ToInt()).ToArray();
            for(int i = 0; intNumbers.Skip(i+1).Any(); i++)
            {
                if (intNumbers[i+1] > intNumbers[i])
                {
                    count++;
                }
            }
            return count;
        }
        
        //IEnumerable.ElementAt is really slow. Use ToArray()
        public static int CountIncreasesWithSelectForElementAt(IEnumerable<string> numbers)
        {
            if (!numbers.Any())
            {
                return 0;
            }
            int count = 0;
            var intNumbers = numbers.Select(n => n.ToInt());
            for (int i = 0; intNumbers.Skip(i + 1).Any(); i++)
            {
                if (intNumbers.ElementAt(i + 1) > intNumbers.ElementAt(i))
                {
                    count++;
                }
            }
            return count;
        }

        public static int CountIncreasesAsString(IEnumerable<string> numbers)
        {
            if (!numbers.Any())
            {
                return 0;
            }

            int count = 0;
            string previousNumber = numbers.First();

            foreach (var line in numbers.Skip(1))
            {
                var number = line;
                if (string.Compare(number, previousNumber, StringComparison.InvariantCulture) > 0)
                {
                    count++;
                }
                previousNumber = number;
            }
            return count;
        }

        public static int CountIncreasesOldSchool(IEnumerable<string> numbers)
        {
            if (!numbers.Any())
            {
                return 0;
            }
            int count = 0;
            var enumerated = numbers.Select(n => n.ToInt()).ToArray();
            //-1 to avoid index out of bounds
            for (int i = 0; i < enumerated.Length - 1; i++)
            {
                if (enumerated[i] < enumerated[i + 1])
                {
                    count++;
                }
            }
            return count;
        }
        //No check for empty enumerable is necessary as for loop is skipped if Length < 2
        public static int CountIncreasesOldSchoolRefactor(IEnumerable<string> numbers)
        {
            int count = 0;
            var enumerated = numbers.Select(n => n.ToInt()).ToArray();
            //-1 to avoid index out of bounds
            for (int i = 0; i < enumerated.Length - 1; i++)
            {
                if (enumerated[i] < enumerated[i + 1])
                {
                    count++;
                }
            }
            return count;
        }
    }
}