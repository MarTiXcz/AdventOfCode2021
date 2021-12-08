using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Utils
{
    public static class InputReader
    {
        public static IEnumerable<string> ReadLines(int day) => ReadLinesFromFilename($"Input/{day}.txt");

        public static IEnumerable<string> ReadLinesFromFilename(string filename)
        {
            return File.ReadLines(filename);
        }
    }
}
