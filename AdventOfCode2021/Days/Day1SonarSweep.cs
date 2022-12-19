using AdventOfCode2021.Utils;

namespace AdventOfCode2021.Days;

/*
 * Day 1 How many measurements are larger than the previous measurement?
 * https://adventofcode.com/2021/day/1
 * Extended: 
 * Consider sums of a three-measurement sliding window. How many sums are larger than the previous sum?
 */
public sealed class Day1SonarSweep
{
    public static void Run()
    {
        try
        {
            var input = InputReader.ReadLinesForDay(day: 1);
            var count = CountIncreasesWithSelectEnumerated(input);
            Console.WriteLine($"{count} measuruments are larger than the previous measurements.");

        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to read file. Reason: {ex.Message}");
        }
    }
    public static void RunExtended()
    {
        try
        {
            var input = InputReader.ReadLinesForDay(day: 1);
            var count = CountSumIncreasesWithSelectEnumerated(input);
            var count2 = CountSumIncreasesWithSelectCleverEnumerated(input);
            Console.WriteLine($"{count} sums are larger than the previous sum.");
            Console.WriteLine($"{count2} sums are larger than the previous sum.");

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

    //fastest
    public static int CountIncreasesWithSelectEnumerated(IEnumerable<string> numbers)
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
        for (int i = 0; i < intNumbers.Length - 1; i++)
        {
            if (intNumbers[i + 1] > intNumbers[i])
            {
                count++;
            }
        }
        return count;
    }

    public static int CountIncreasesWithSelectForSkipAny(IEnumerable<string> numbers)
    {
        if (!numbers.Any())
        {
            return 0;
        }
        int count = 0;
        var intNumbers = numbers.Select(n => n.ToInt()).ToArray();
        for (int i = 0; intNumbers.Skip(i + 1).Any(); i++)
        {
            if (intNumbers[i + 1] > intNumbers[i])
            {
                count++;
            }
        }
        return count;
    }

    // IEnumerable.ElementAt is really slow. Use implementation with ToArray()
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

    //Part TWO

    public static int CountSumIncreasesWithSelectEnumerated(IEnumerable<string> numbers)
    {
        return CountSumIncreasesWithSelect(numbers.Select(n => n.ToInt()).ToArray());
    }

    public static int CountSumIncreasesWithSelectCleverEnumerated(IEnumerable<string> numbers)
    {
        return CountSumIncreasesWithSelectClever(numbers.Select(n => n.ToInt()).ToArray());
    }

    public static int CountSumIncreasesWithSelect(int[] numbers)
    {
        if (!numbers.Any())
        {
            return 0;
        }
        int count = 0;
        int previousSum = numbers[0] + numbers[1] + numbers[2];
        for (int i = 1; i < numbers.Length - 2; i++)
        {
            var firstNumber = numbers[i];
            var secondNumber = numbers[i + 1];
            var thirdNumber = numbers[i + 2];
            var newSum = firstNumber + secondNumber + thirdNumber;
            if (previousSum < newSum)
            {
                count++;
            }
            previousSum = newSum;
        }

        return count;
    }


    /*
     * This only checks if the next number is greater than the one we are moving from
     * 199 200 208 210. One sliding window is 199 200 208. Next one is 200 208 210.
     * We only need to check if 210 > 199 to know that the sum would be greater.
     */
    public static int CountSumIncreasesWithSelectClever(int[] numbers)
    {
        if (!numbers.Any())
        {
            return 0;
        }
        int count = 0;
        int previousNumber = numbers[0];
        for (int i = 1; i < numbers.Length - 2; i++)
        {
            var firstNumber = numbers[i];
            //var secondNumber = numbers[i + 1];
            var thirdNumber = numbers[i + 2];
            //var newSum = firstNumber + secondNumber + thirdNumber;
            if (previousNumber < thirdNumber)
            {
                count++;
            }
            previousNumber = firstNumber;
        }

        return count;
    }
}
