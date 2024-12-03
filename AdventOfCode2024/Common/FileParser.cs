namespace Common
{
    public class FileParser
    {
        public static IEnumerable<T> ReadAllLinesAsType<T>(string filepath, IFormatProvider? provider = null) where T : IParsable<T> => File.ReadAllLines(filepath).Select(s => T.Parse(s, provider));
        public static IEnumerable<string> ReadAllLines(string filepath) => ReadAllLinesAsType<string>(filepath);
        public static IEnumerable<int> ReadAllLinesAsInt(string filepath) => ReadAllLinesAsType<int>(filepath);
        public static IEnumerable<int[]> ReadAllLinesAsIntArrays(string filepath) => File.ReadAllLines(filepath).Select(s => s.Split(' ').Select(t => int.Parse(t)).ToArray());
    }
}
