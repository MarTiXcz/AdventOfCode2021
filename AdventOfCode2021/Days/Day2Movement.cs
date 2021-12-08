using AdventOfCode2021.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days;
public class Day2Submarine
{
    public int HorizontalPosition { get; set; } = 0;
    public int Depth { get; set; } = 0;
    public int AbsolutePosition => HorizontalPosition * Depth;

    public int Aim { get; set; } = 0;
    public void Update(Day2Movement.Move move)
    {
        switch (move.Direction)
        {
            case Day2Movement.Direction.Unknown:
                break;
            case Day2Movement.Direction.Forward:
                HorizontalPosition += move.Delta;
                break;
            case Day2Movement.Direction.Up:
                Depth -= move.Delta;
                break;
            case Day2Movement.Direction.Down:
                Depth += move.Delta;
                break;
            default:
                break;
        }
    }
    public void CorrectedUpdate(Day2Movement.Move move)
    {
        switch (move.Direction)
        {
            case Day2Movement.Direction.Unknown:
                break;
            case Day2Movement.Direction.Forward:
                HorizontalPosition += move.Delta;
                Depth += Aim * move.Delta;
                break;
            case Day2Movement.Direction.Up:
                Aim -= move.Delta;
                break;
            case Day2Movement.Direction.Down:
                Aim += move.Delta;
                break;
            default:
                break;
        }
    }
}
public class Day2Movement
{
    public record Move
    {
        public Direction Direction;
        public int Delta;
    }
    public enum Direction
    {
        Unknown = 0,
        Forward = 1,
        Up = 2,
        Down = 3,
    }
    public static void Run()
    {
        try
        {
            var input = InputReader.ReadLines(day: 2);
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

    public static int CalculatePosition(IEnumerable<string> input)
    {
        Day2Submarine submarine = new();
        foreach (var line in input)
        {
            var move = ReadMove(line);
            submarine.Update(move);
        }
        return submarine.AbsolutePosition;
    }
    public static int CalculateCorrectedPosition(IEnumerable<string> input)
    {
        Day2Submarine submarine = new();
        foreach (var line in input)
        {
            var move = ReadMove(line);
            submarine.CorrectedUpdate(move);
        }
        return submarine.AbsolutePosition;
    }

    public static Move ReadMove(string line)
    {
        var span = line.AsSpan();
        var direction = CharToDirection(span[0]);
        var delta = span[span.LastIndexOf(' ')..].ToInt();
        return new Move() { Direction = direction, Delta = delta };
    }

    private static Direction CharToDirection(char firstChar)
    {
        switch (firstChar)
        {
            case 'f':
                return Direction.Forward;
            case 'u':
                return Direction.Up;
            case 'd':
                return Direction.Down;
            default:
                return Direction.Unknown;
        }
    }
}
