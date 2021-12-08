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
    }
}
