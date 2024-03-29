﻿using AdventOfCode2021.Core.Types;
using AdventOfCode2021.Days;
using AdventOfCode2021.Utils;

namespace AdventOfCode2021.Core
{
    public sealed class Submarine : IMovable
    {
        public int GammaRate { get; set; } = 0;
        public int EpsilonRate { get; set; } = 0;
        public int PowerConsumption => GammaRate * EpsilonRate;
        public int OxygenRating { get; private set; }


        public int HorizontalPosition { get; set; } = 0;
        public int Depth { get; set; } = 0;
        public int AbsolutePosition => HorizontalPosition * Depth;

        public int Aim { get; set; } = 0;

        public void ChangePosition(Move move)
        {
            switch (move.Direction)
            {
                case Direction.Unknown:
                    break;
                case Direction.Forward:
                    HorizontalPosition += move.Delta;
                    break;
                case Direction.Up:
                    Depth -= move.Delta;
                    break;
                case Direction.Down:
                    Depth += move.Delta;
                    break;
                default:
                    break;
            }
        }

        public void ChangePositionWithCorrection(Move move)
        {
            switch (move.Direction)
            {
                case Direction.Unknown:
                    break;
                case Direction.Forward:
                    HorizontalPosition += move.Delta;
                    Depth += Aim * move.Delta;
                    break;
                case Direction.Up:
                    Aim -= move.Delta;
                    break;
                case Direction.Down:
                    Aim += move.Delta;
                    break;
                default:
                    break;
            }
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
            return firstChar switch
            {
                'f' => Direction.Forward,
                'u' => Direction.Up,
                'd' => Direction.Down,
                _ => Direction.Unknown,
            };
        }

        public void ImportDiagnosticsNaiveAsSpan(IEnumerable<string> diagnostics)
        {
            var totalCount = diagnostics.Count();
            for (int i = 0; i < diagnostics.First().Length; i++)
            {
                var count = diagnostics.Sum(d => d.AsSpan()[i]);
                if ((count - totalCount * '0') > totalCount / 2)
                {
                    GammaRate |= 0x1 << diagnostics.First().Length - 1 - i;
                }
                else
                {
                    EpsilonRate |= 0x1 << diagnostics.First().Length - 1 - i;
                }
            }
        }

        public void ImportDiagnosticsNaive(IEnumerable<string> diagnostics)
        {
            var totalCount = diagnostics.Count();
            for (int i = 0; i < diagnostics.First().Length; i++)
            {
                var count = diagnostics.Sum(d => d[i]);
                if ((count - totalCount * '0') > totalCount / 2)
                {
                    GammaRate |= 0x1 << diagnostics.First().Length - 1 - i;
                }
                else
                {
                    EpsilonRate |= 0x1 << diagnostics.First().Length - 1 - i;
                }
            }
        }

        public void ImportExtendedDiagnostics(IEnumerable<string> diagnostics)
        {
            var totalCount = diagnostics.Count();
            var bitLength = diagnostics.First().Length;
            char x = '0';
            var searchEnumerable = diagnostics;
            for (int i = 0; i < bitLength; i++)
            {
                var count = searchEnumerable.Sum(d => d.AsSpan()[i] - '0');
                totalCount = searchEnumerable.Count();
                if ((totalCount - count) <= totalCount / 2)
                {
                    x = '1';
                }
                else
                {
                    x = '0';
                }
                searchEnumerable = searchEnumerable.Where(d => d.AsSpan()[i] == x).ToList();
                if (searchEnumerable.Take(2).Count() == 1)
                {
                    Console.WriteLine(searchEnumerable.First());
                    OxygenRating = Convert.ToInt32(searchEnumerable.First(), 2);
                    break;
                }
            }
        }
    }
}
