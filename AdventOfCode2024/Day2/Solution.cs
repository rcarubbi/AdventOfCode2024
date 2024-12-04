
using FluentAssertions;
using System.Diagnostics;

namespace AdventOfCode2024.Day2;

public partial class Solution
{

    private static List<int[]> GetInput()
    {
        var lines = File.ReadAllLines("Day2\\Input.txt");

        var reportsData = new List<int[]>();
        foreach (var line in lines)
        {
            reportsData.Add(line.Split(' ').Select(int.Parse).ToArray());
        }

        return reportsData;
    }


    [Fact]
    public void Task1()
    {
        var reportsData = GetInput();
        var safeReports = 0;
        foreach (var levels in reportsData)
        {
            var r = new Report(levels);
            if (r.IsSafe())
            {
                safeReports++;
            }
        }

        Debug.WriteLine($"Day 2, Task 1 answer is: {safeReports}");
        safeReports.Should().Be(279);

    }

    [Fact]
    public void Task2()
    {
        var reportsData = GetInput();
        var safeReports = 0;
        foreach (var levels in reportsData)
        {
            var r = new Report(levels);
            if (r.IsSafe())
            {
                safeReports++;
            }
            else
            {
                var pd = new ProblemDampener(r);
                if (pd.IsSafe())
                {
                    safeReports++;
                }
            }
        }

        Debug.WriteLine($"Day 2, Task 2 answer is: {safeReports}");
        safeReports.Should().Be(343);
    }
}