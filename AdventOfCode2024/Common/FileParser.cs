using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Common
{
    public class FileParser
    {
        public static string ReadAllLinesAsText(string filepath) => File.ReadAllText(filepath);
        public static IEnumerable<T> ReadAllLinesAsType<T>(string filepath, IFormatProvider? provider = null) where T : IParsable<T> => File.ReadAllLines(filepath).Select(s => T.Parse(s, provider));
        public static IEnumerable<string> ReadAllLines(string filepath) => ReadAllLinesAsType<string>(filepath);
        public static IEnumerable<int> ReadAllLinesAsInt(string filepath) => ReadAllLinesAsType<int>(filepath);
        public static IEnumerable<int[]> ReadAllLinesAsIntArrays(string filepath) => File.ReadAllLines(filepath).Select(s => s.Split(' ').Select(t => int.Parse(t)).ToArray());
        
        public static char[,] ReadAllLinesAsCharGrid(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var length = lines.Length;
            var width = lines[0].Length;
            var data = new char[length, width];

            if (lines.Any(l => l.Length != width))
                throw new ArgumentException("Grid lines are not of equal width!");

            for (int y = 0; y < length; y++)
                for (int x = 0; x < width; x++)
                    data[x, y] = lines[y][x];

            return data;
        }
    }
}
