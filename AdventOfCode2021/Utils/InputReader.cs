namespace AdventOfCode2021.Utils
{
    public static class InputReader
    {
        public static IEnumerable<string> ReadLinesForDay(int day) => ReadLinesFromFilename($"Input/{day}.txt");

        public static IEnumerable<string> ReadLinesFromFilename(string filename)
        {
            return File.ReadLines(filename);
        }
    }
}
