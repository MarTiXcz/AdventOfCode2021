using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Core
{
    public class Submarine
    {
        public int GammaRate { get; set; } = 0;
        public int EpsilonRate { get; set; } = 0;
        public int PowerConsumption => GammaRate * EpsilonRate;

        public int OxygenRating { get; private set; }

        public void ImportDiagnosticsNaive(IEnumerable<string> diagnostics)
        {
            var totalCount = diagnostics.Count();
            for (int i = 0; i < diagnostics.First().Length; i++)
            {
                var count = diagnostics.Sum(d => d.AsSpan()[i]);
                if((count - totalCount * '0') > totalCount/2)
                {
                    GammaRate |= 0x1 << diagnostics.First().Length - 1 - i;
                }
                else
                {
                    EpsilonRate |= 0x1 << diagnostics.First().Length - 1 - i;
                }
            }
        }
        public void ImportDiagnosticsNaiveString(IEnumerable<string> diagnostics)
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
            //StringBuilder prefix = new();
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
                if(searchEnumerable.Take(2).Count() == 1)
                {
                    Console.WriteLine(searchEnumerable.First());
                    OxygenRating = Convert.ToInt32(searchEnumerable.First(), 2);
                    break;
                }
            }
        }
    }
}
