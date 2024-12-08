using FluentAssertions;
using System.Diagnostics;

namespace AdventOfCode2024.Day8;

public class Solution
{
    private static string[] GetInput()
    {
        var content = File.ReadAllLines("Day8\\input.txt");

        return content;
    }

    [Fact]
    public async Task Task1()
    {
        var map = GetInput();
        var calculator = new ClassicAntinodeCalculator();
        var repository = new MapRepository();
        var counter = new AntinodeCounter(repository, calculator);

        int result = counter.CountUniqueAntinodes(map);
        result.Should().Be(289);
        Debug.WriteLine($"Day 8, Task 1 answer is: {result}");
    }

    [Fact]
    public async Task Task2()
    {
        var map = GetInput();
        var repository = new MapRepository();
        var calculator = new ResonantAntinodeCalculator(map[0].Length, map.Length);
        var counter = new AntinodeCounter(repository, calculator);

        int result = counter.CountUniqueAntinodes(map);
        result.Should().Be(1030);
        Debug.WriteLine($"Day 8, Task 2 answer is: {result}");
    }
}
