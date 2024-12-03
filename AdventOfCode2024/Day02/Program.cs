
using Common;

// Puzzle answers
var safeReports = 0;
var dampenedReports = 0;

// Read in each report
var reports = FileParser.ReadAllLinesAsIntArrays("input.txt");

// Parse each line
foreach (var report in reports)
{
    // Lists for determining safe reports
    var deltas = new List<int>();
    var dirs = new List<char>();

    // Markers for any invalid levels
    var invDelta = -1;
    var invDir = -1;

    // Compute the difference and direction for each element
    for (int i = 1; i < report.Length; i++)
    {
        var delta = Math.Abs(report[i] - report[i - 1]);
        var dir = (report[i] - report[i - 1]) > 0 ? '+' : '-';

        deltas.Add(delta);
        dirs.Add(dir);

        if (delta > 3 || delta < 1)
            invDelta = i;
        if (dir != dirs[0])
            invDir = i;
    }

    // Check to see if this report is safe
    if (invDelta == -1 && invDir == -1)
        safeReports += 1;

    // Try removing one invalid level
    if (invDelta > 0)
    {
        deltas.RemoveAt(invDelta);
        dirs.RemoveAt(invDelta);
    }
    else if (invDir > 0)
    {
        deltas.RemoveAt(invDir);
        dirs.RemoveAt(invDir);
    }

    // Check to see if the report is safe after removing a level
    var safeDelta = deltas.All(d => d <= 3 && d >= 1);
    var safeDir = dirs.All(d => d == dirs[0]);
    
    // Count the report if it's safe
    if (safeDelta && safeDir)
        dampenedReports += 1;

    // Debug
    //Console.WriteLine($"{string.Join(' ', report)}");
    //Console.WriteLine($"  {string.Join(' ', deltas)}");
    //Console.WriteLine($"  {string.Join(' ', dirs)}");
    //Console.WriteLine($"  {invDelta} {invDir}");
    //Console.WriteLine();
}

Console.WriteLine(safeReports);
Console.WriteLine(dampenedReports);
