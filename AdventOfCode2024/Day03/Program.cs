
using Common;
using System.Text.RegularExpressions;

// Puzzle answers
var sumOfProducts = 0;
var sumOfConditionalProducts = 0;
var enabled = true;

// Read in the input
var memory = FileParser.ReadAllLinesAsText("input.txt");
var opertations = Regex.Matches(memory, @"mul\([0-9]*,[0-9]*\)|do\(\)|don\'t\(\)");

// Parse each line
foreach (var operation in opertations)
{
    // Find enable/disable first
    if (operation.ToString().ToLower() == "do()")
    {
        enabled = true;
        continue;
    }
    if (operation.ToString().ToLower() == "don't()")
    {
        enabled = false;
        continue;
    }

    // Parse the operation
    var tokens = operation.ToString().Split(',');
    var operand1 = int.Parse(tokens[0].Replace("mul(", ""));
    var operand2 = int.Parse(tokens[1].Replace(")", ""));

    // Always add result to part one answer
    sumOfProducts += operand1 * operand2;

    // Conditionally add result to part two answer
    if (enabled)
        sumOfConditionalProducts += operand1 * operand2;
}

// Print results
Console.WriteLine(sumOfProducts);
Console.WriteLine(sumOfConditionalProducts);
