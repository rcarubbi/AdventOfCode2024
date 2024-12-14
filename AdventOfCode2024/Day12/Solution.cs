using FluentAssertions;

namespace AdventOfCode2024.Day12;

public class Solution
{
    [Fact]
    public void Task1()
    {
        var map = GetInput();
        var gardenMap = new Map(map);
        var regions = gardenMap.IdentifyRegions();
        int total = 0;

        foreach (var region in regions)
        {
            int perimeter = region.CalculatePerimeter();

            total += region.Area * perimeter;
        }

        total.Should().Be(1_370_258);
    }

    private char[,] GetInput()
    {
        var input = File.ReadAllLines("Day12\\input.txt");
        int rows = input.Length;
        int cols = input[0].Length;
        char[,] map = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                map[i, j] = input[i][j];
            }
        }

        return map;
    }

    [Fact]
    public void Task2()
    {
        var map = GetInput();

        var gardenMap = new Map(map);
        var regions = gardenMap.IdentifyRegions();
        int total = 0;

        foreach (var region in regions)
        {
            int uniqueSides = region.CalculateUniqueSides();

            total += region.Area * uniqueSides;
        }


        total.Should().Be(805_814);
    }
}