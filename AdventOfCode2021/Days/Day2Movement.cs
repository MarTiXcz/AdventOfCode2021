using AdventOfCode2021.Core;
using AdventOfCode2021.Utils;

namespace AdventOfCode2021.Days;
/*
 * Day 2
 * https://adventofcode.com/2021/day/2
 */
public sealed class Day2Movement
{
    public static void Run()
    {
        try
        {
            var input = InputReader.ReadLinesForDay(day: 2);
            var position = CalculatePosition(input);
            Console.WriteLine($"Position is {position}");
            var correctedPosition = CalculateCorrectedPosition(input);
            Console.WriteLine($"Corrected Position is {correctedPosition}");


        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to read file. Reason: {ex.Message}");
        }
    }

    /*
     * It seems like the submarine can take a series of commands like forward 1, down 2, or up 3:
        forward X increases the horizontal position by X units.
        down X increases the depth by X units.
        up X decreases the depth by X units.
        Note that since you're on a submarine, down and up affect your depth, and so they have the opposite result of what you might expect.
     */
    public static int CalculatePosition(IEnumerable<string> input)
    {
        Submarine submarine = new();
        foreach (var line in input)
        {
            var move = Submarine.ReadMove(line);
            submarine.ChangePosition(move);
        }
        return submarine.AbsolutePosition;
    }

    /*
     * In addition to horizontal position and depth, you'll also need to track a third value, aim, which also starts at 0. The commands also mean something entirely different than you first thought:
        down X increases your aim by X units.
        up X decreases your aim by X units.
        forward X does two things:
        It increases your horizontal position by X units.
        It increases your depth by your aim multiplied by X.
     */
    public static int CalculateCorrectedPosition(IEnumerable<string> input)
    {
        Submarine submarine = new();
        foreach (var line in input)
        {
            var move = Submarine.ReadMove(line);
            submarine.ChangePositionWithCorrection(move);
        }
        return submarine.AbsolutePosition;
    }
}
