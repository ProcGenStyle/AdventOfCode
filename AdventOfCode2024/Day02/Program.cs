
using Common;

// Puzzle answers
var safeReports = 0;
var dampenedReports = 0;
var itemRemoved = false;

// Read in each report
var reports = FileParser.ReadAllLinesAsIntArrays("input.txt");

// Parse each line
foreach (var report in reports)
{
    // Lists for determining safe reports
    var deltas = new List<int>();
    var dirs = new List<char>();

    // Compute the difference and direction for each element
    for (int i = 1; i < report.Length; i++)
    {
        var delta = report[i] - report[i - 1];
        deltas.Add(Math.Abs(delta));
        dirs.Add(delta > 0 ? '+' : delta < 0 ? '-' : '0');
    }

    // Check to see if this report is safe
    if (deltas.All(d => d <= 3 && d >= 1) && dirs.All(d => d == dirs[0]))
        safeReports += 1;

    // Debug
    Console.WriteLine($"{string.Join('\t', report)}");
    Console.WriteLine($"\t{string.Join('\t', deltas)}");
    Console.WriteLine($"\t{string.Join('\t', dirs)}");

    // Try removing one invalid level
    for (int i = deltas.Count - 1; i >= 0; i--)
    {
        if (deltas[i] > 3 || deltas[i] < 1)
        {
            Console.WriteLine($"Removed {deltas[i]} {dirs[i]}");
            deltas.RemoveAt(i);
            dirs.RemoveAt(i);
            itemRemoved = true;
            break;
        }
    }

    // Check to see if a dir needs to be removed
    var tot = dirs.Count();
    var plus = dirs.Count(c => c == '+');
    var minus = dirs.Count(c => c == '-');
    if (plus > minus && plus != tot && !itemRemoved)
    {
        var i = dirs.IndexOf('-');
        Console.WriteLine($"Removed {deltas[i]} {dirs[i]}");
        deltas.RemoveAt(i);
        dirs.RemoveAt(i);
    }
    else if (minus > plus && minus != tot && !itemRemoved)
    {
        var i = dirs.IndexOf('+');
        Console.WriteLine($"Removed {deltas[i]} {dirs[i]}");
        deltas.RemoveAt(i);
        dirs.RemoveAt(i);
    }

    // Check again to see if this report is safe after removing a level
    if (deltas.All(d => d <= 3 && d >= 1) && dirs.All(d => d == dirs[0]))
    {
        dampenedReports += 1;
        Console.WriteLine("Safe");
    }
    else { Console.WriteLine("Unsafe"); }
    Console.WriteLine();

    // Reset removed flag for next cycle
    itemRemoved = false;
}

// Print results
Console.WriteLine(safeReports);
Console.WriteLine(dampenedReports);
