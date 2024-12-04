
using FluentAssertions;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3;

public class Solution
{

    private static string GetInput()
    {
        var content = File.ReadAllText("Day3\\Input.txt");

        return content;
    }


    [Fact]
    public void Task1()
    {
        var memoryDump = GetInput();

        string pattern = @"
            mul\(            # Matches the literal text 'mul('
            (\d{1,3})        # Captures the first number (x), which must be 1 to 3 digits
            ,                # Matches the comma separator
            (\d{1,3})        # Captures the second number (y), which must also be 1 to 3 digits
            \)               # Matches the literal closing parenthesis ')'
        ";

        MatchCollection matches = Regex.Matches(memoryDump, pattern, RegexOptions.IgnorePatternWhitespace);
        var sum = 0;

        foreach (Match match in matches)
        {
            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);
            sum += x * y;
        }


        Debug.WriteLine($"Day 3, Task 1 answer is: {sum}");
        sum.Should().Be(189_600_467);
    }

    [Fact]
    public void Task2()
    {
        var memoryDump = GetInput();

        string pattern = @"
            mul\(            # Matches the literal text 'mul('
            (\d{1,3})        # Captures the first number (x), which must be 1 to 3 digits
            ,                # Matches the comma separator
            (\d{1,3})        # Captures the second number (y), which must also be 1 to 3 digits
            \)               # Matches the literal closing parenthesis ')'
        ";

        Regex regex = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);


        bool isEnabled = true;
        int sum = 0;


        string splitPattern = @"
            (?<=\))              # Matches positions immediately after a closing parenthesis ')'
            |                    # OR
            (?=\b(?:do\(\)|don't\(\))) # Matches positions immediately before 'do()' or 'don't()'
        ";


        string[] tokens = Regex.Split(memoryDump, splitPattern, RegexOptions.IgnorePatternWhitespace);

        foreach (var token in tokens)
        {
            if (token == "do()")
            {
                isEnabled = true;
            }
            else if (token == "don't()")
            {
                isEnabled = false;
            }
            else
            {

                Match match = regex.Match(token);
                if (match.Success && isEnabled)
                {

                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);


                    sum += x * y;
                }
            }
        }

        Debug.WriteLine($"Day 3, Task 2 answer is: {sum}");
        sum.Should().Be(107_069_718);
    }
}