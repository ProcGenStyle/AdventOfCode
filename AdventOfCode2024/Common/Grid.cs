using System.Text;

namespace Common
{
    public class Grid<T>
    {
        public int Length { get; set; }
        public int Width { get; set; }

        private T[,] data;

        public Grid(int length, int width)
        {
            Length = length;
            Width = width;
            data = new T[length, width];
        }
    }
}
