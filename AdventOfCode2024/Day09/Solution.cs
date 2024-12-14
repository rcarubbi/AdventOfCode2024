using FluentAssertions;
using System.Diagnostics;

namespace AdventOfCode2024.Day09;

public class Solution
{
    private static string GetInput()
    {
         return File.ReadAllText("Day09\\input.txt");
    }

    [Fact]
    public void Task1()
    {
        var input = GetInput();
        var parser = new DiskParser();
        var checksumCalculator = new ChecksumCalculator();
        var manager = new DiskManager(parser, checksumCalculator);

        var part1Strategy = new BlockByBlockCompactionStrategy();
    
        long checksum = manager.ProcessDisk(input, part1Strategy);

        Debug.WriteLine($"Day 9, Task 1 answer is: {checksum}");
        checksum.Should().Be(6_395_800_119_709);
    }

    [Fact]
    public void Task2()
    {
        var input = GetInput();
        var parser = new DiskParser();
        var checksumCalculator = new ChecksumCalculator();
        var manager = new DiskManager(parser, checksumCalculator);

        var part2Strategy = new WholeFileCompactionStrategy();

        long checksum = manager.ProcessDisk(input, part2Strategy);
        Debug.WriteLine($"Day 9, Task 2 answer is: {checksum}");
        checksum.Should().Be(6_418_529_470_362);
    }
}