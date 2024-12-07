using FluentAssertions;
using System.Diagnostics;

namespace AdventOfCode2024.Day6;

public class Solution
{
    private static char[][] GetInput()
    {
        var content = File.ReadAllLines("Day6\\Input.txt");
        return content.Select(x => x.ToCharArray()).ToArray();
    }

    [Fact]
    public void Task1()
    {
        var maze = GetInput();

        var pathTracker = new PathTracker(maze);

        var positionsVisited = pathTracker.CountGuardDistinctPositions();

        positionsVisited.Should().Be(4433);
        Debug.WriteLine($"Day 6, Task 1 answer is: {positionsVisited}");
    }



    [Fact]
    public void Task2()
    {
        var maze = GetInput();
        var pathTracker = new PathTracker(maze);
        var loopDetector = new LoopDetector(pathTracker);

        var positionsVisited = loopDetector.CountPossibleObstructionPositions();

        positionsVisited.Should().Be(1516);
        Debug.WriteLine($"Day 6, Task 2 answer is: {positionsVisited}");
    }
}
