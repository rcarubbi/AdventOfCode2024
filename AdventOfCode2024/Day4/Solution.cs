using FluentAssertions;
using System.Diagnostics;

namespace AdventOfCode2024.Day4;

public partial class Solution
{

    private static string[] GetInput()
    {
        var content = File.ReadAllLines("Day4\\Input.txt");

        return content;
    }

    [Fact]
    public void Task1()
    {
        var grid = GetInput();
        var workSeeker = new WordSeeker(grid);
        const string Word = "XMAS";
        int totalOccurrences = workSeeker.CountOccurrences(Word);
        Debug.WriteLine($"Day 4, Task 1 answer is: {totalOccurrences}");
        totalOccurrences.Should().Be(2554);
    }


    [Fact]
    public void Task2()
    {
        var grid = GetInput();
        XmasPatternSeeker xmasPatternSeeker = new XmasPatternSeeker(grid);
        int totalXMas = xmasPatternSeeker.CountOccurrences();

        Debug.WriteLine($"Day 4, Task 2 answer is: {totalXMas}");
        totalXMas.Should().Be(1916);
    }
}