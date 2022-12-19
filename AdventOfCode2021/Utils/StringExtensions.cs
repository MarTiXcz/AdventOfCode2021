namespace AdventOfCode2021.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// throws
        /// </summary>
        /// <param name="str"></param>
        /// <exception cref="FormatException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OverflowException"/>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            return int.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static int ToInt(this ReadOnlySpan<char> str)
        {
            return int.Parse(str);
        }
    }
}
