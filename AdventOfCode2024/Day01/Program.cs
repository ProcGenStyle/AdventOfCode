
using Common;

// Set up lists to store location Ids
var idList = new List<int>();
var idMap = new Dictionary<int, List<int>>();

// Set up result values
var sumOfDifference = 0;
var sumOfSimiliarity = 0;

// Read each line of input
var lines = FileParser.ReadAllLines("input.txt");

// Parse each line
foreach (var line in lines)
{
    // Split each line into seperate location ids
    var tokens = line.Split("   ");

    // Add id to list one
    idList.Add(int.Parse(tokens[0]));

    // Add id and occurance count to the map
    var id2 = int.Parse(tokens[1]);

    if (idMap.ContainsKey(id2))
        idMap[id2].Add(id2);
    else
        idMap.Add(id2, [id2]);
}

// Flatten the keys and values of the dictionary to get the second list of ids
var idKeys = idMap.SelectMany(s => s.Value).ToList();

// Sort each id list so the smallest numbers are in front
idKeys.Sort();
idList.Sort();

// Compute the sum of the distances and the similarity scores
for (var i = 0; i < idList.Count; i++)
{
    sumOfDifference += Math.Abs(idList[i] - idKeys[i]);
    sumOfSimiliarity += idList[i] * (idMap.ContainsKey(idList[i]) ? idMap[idList[i]].Count : 0);
}

// Print the results
Console.WriteLine(sumOfDifference);
Console.WriteLine(sumOfSimiliarity);
