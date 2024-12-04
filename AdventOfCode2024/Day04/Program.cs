
using Common;
using System.Text;

// Puzzle answers
var countOfXmas = 0;
var countOfMasX = 0;

// Read in the input
var grid = FileParser.ReadAllLinesAsCharGrid("input.txt");

// Search for words
for (int y = 0; y < grid.GetLength(0); y++)
{
    for (int x = 0; x < grid.GetLength(1); x++)
    {
        // If cell is X, check all directions
        if (grid[x, y] == 'X')
            countOfXmas += CheckForXmas(x, y);

        // If cell is M, check all diagonals
        if (grid[x, y] == 'A')
            countOfMasX += CheckForMasX(x, y);
    }
}

// Print results
//PrintGrid();
Console.WriteLine(countOfXmas);
Console.WriteLine(countOfMasX);

// Start at grid[x, y] and check all directions for XMAS
int CheckForXmas(int x, int y)
{
    // Result
    var count = 0;

    // Confirm starting on X
    if (grid[x, y] != 'X')
        return count;

    // Check to the right
    if (
        grid.GetLength(0) > x + 3 &&
        grid[x + 1, y] == 'M' &&
        grid[x + 2, y] == 'A' &&
        grid[x + 3, y] == 'S'
    )
        count++;

    // Check to the left
    if (
        0 <= x - 3 &&
        grid[x - 1, y] == 'M' &&
        grid[x - 2, y] == 'A' &&
        grid[x - 3, y] == 'S'
    )
        count++;

    // Check up
    if (
        0 <= y - 3 &&
        grid[x, y - 1] == 'M' &&
        grid[x, y - 2] == 'A' &&
        grid[x, y - 3] == 'S'
    )
        count++;

    // Check down
    if (
        grid.GetLength(1) > y + 3 &&
        grid[x, y + 1] == 'M' &&
        grid[x, y + 2] == 'A' &&
        grid[x, y + 3] == 'S'
    )
        count++;

    // Check top right
    if (
        grid.GetLength(0) > x + 3 &&
        0 <= y - 3 &&
        grid[x + 1, y - 1] == 'M' &&
        grid[x + 2, y - 2] == 'A' &&
        grid[x + 3, y - 3] == 'S'
    )
        count++;

    // Check top left
    if (
        0 <= x - 3 &&
        0 <= y - 3 &&
        grid[x - 1, y - 1] == 'M' &&
        grid[x - 2, y - 2] == 'A' &&
        grid[x - 3, y - 3] == 'S'
    )
        count++;

    // Check bottom right
    if (
        0 <= x - 3 &&
        grid.GetLength(1) > y + 3 &&
        grid[x - 1, y + 1] == 'M' &&
        grid[x - 2, y + 2] == 'A' &&
        grid[x - 3, y + 3] == 'S'
    )
        count++;

    // Check bottom left
    if (
        grid.GetLength(0) > x + 3 &&
        grid.GetLength(1) > y + 3 &&
        grid[x + 1, y + 1] == 'M' &&
        grid[x + 2, y + 2] == 'A' &&
        grid[x + 3, y + 3] == 'S'
    )
        count++;


    return count;
}

// Start at grid[x, y] and check all diagonals for MAS
int CheckForMasX(int x, int y)
{
    // Result
    var count = 0;

    // Confirm starting on X
    if (grid[x, y] != 'A')
        return count;

    // Save diagonal letters for checking later
    char topRight = '-';
    char topLeft = '-';
    char bottomRight = '-';
    char bottomLeft = '-';

    // Get directions
    if (grid.GetLength(0) > x + 1 && 0 <= y - 1) topRight = grid[x + 1, y - 1];
    if (0 <= x - 1 && 0 <= y - 1) topLeft = grid[x - 1, y - 1];
    if (grid.GetLength(0) > x + 1 && grid.GetLength(1) > y + 1) bottomRight = grid[x + 1, y + 1];
    if (0 <= x - 1 && grid.GetLength(1) > y + 1) bottomLeft = grid[x - 1, y + 1];

    // Check directions
    if (topLeft == '-' || topRight == '-' || bottomLeft == '-' || bottomRight == '-') return count;
    if (topLeft == 'M' && topRight == 'M' && bottomLeft == 'S' && bottomRight == 'S') count++;
    if (topLeft == 'S' && topRight == 'S' && bottomLeft == 'M' && bottomRight == 'M') count++;
    if (topLeft == 'M' && topRight == 'S' && bottomLeft == 'M' && bottomRight == 'S') count++;
    if (topLeft == 'S' && topRight == 'M' && bottomLeft == 'S' && bottomRight == 'M') count++;

    return count;
}

void PrintGrid()
{
    var sb = new StringBuilder();

    for (int y = 0; y < grid.GetLength(0); y++)
    {
        for (int x = 0; x < grid.GetLength(1); x++)
        {
            sb.Append(grid[x, y]);
        }
        sb.AppendLine();
    }

    Console.WriteLine(sb.ToString());
}
