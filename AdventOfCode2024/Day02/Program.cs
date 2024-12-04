
using Common;

// Puzzle answers
var safeReports = 0;
var dampenedReports = 0;
var levelRemovedSafe = false;

// Read in each report
var reports = FileParser.ReadAllLinesAsIntArrays("input.txt");

// Parse each line
foreach (var report in reports)
{
    // Lists for determining safe reports
    var deltas = new List<int>();
    var dirs = new List<char>();
    var listOfLists = new List<List<int>>();
    var reportLength = report.Length;

    // Compute the difference and direction for each element
    listOfLists.Add(report.ToList());
    for (int i = 1; i < report.Length; i++)
    {
        listOfLists.Add(report.ToList());
        var delta = report[i] - report[i - 1];
        deltas.Add(Math.Abs(delta));
        dirs.Add(delta > 0 ? '+' : delta < 0 ? '-' : '0');
    }

    // Check to see if this report is safe
    if (deltas.All(d => d <= 3 && d >= 1) && dirs.All(d => d == dirs[0]))
        safeReports += 1;

    // Remove one element from each list
    for (var i = 0; i < reportLength; i++)
        listOfLists[i].RemoveAt(i);

    // Brute force check with one level removed
    foreach (var newReport in listOfLists)
    {
        var newDeltas = new List<int>();
        var newDirs = new List<char>();
        for (int i = 1; i < newReport.Count; i++)
        {
            var delta = newReport[i] - newReport[i - 1];
            newDeltas.Add(Math.Abs(delta));
            newDirs.Add(delta > 0 ? '+' : delta < 0 ? '-' : '0');
        }

        if (newDeltas.All(d => d <= 3 && d >= 1) && (newDirs.All(d => d == '-') || newDirs.All(d => d == '+')))
            levelRemovedSafe = true;
    }

    // Check again to see if this report is safe after removing a level
    if (levelRemovedSafe)
        dampenedReports += 1;

    // Reset removed flag for next cycle
    levelRemovedSafe = false;
}

// Print results
Console.WriteLine(safeReports);
Console.WriteLine(dampenedReports);
