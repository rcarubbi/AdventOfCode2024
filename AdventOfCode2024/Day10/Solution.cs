
using FluentAssertions;

namespace AdventOfCode2024.Day10;

public class Solution
{

    [Fact]
    public void Task1()
    {
        int[,] heights = GetInput();
        var map = new TopographicMap(heights);
        var analyzer = new TrailheadAnalyzer(map);

        int totalScore = analyzer.CalculateTotalScore();
        totalScore.Should().Be(719);
    }

    [Fact]
    public void Task2()
    {
        int[,] heights = GetInput();
        var map = new TopographicMap(heights);
        var analyzer = new TrailheadAnalyzer(map);
        int totalRating = analyzer.CalculateTotalRating();
        totalRating.Should().Be(1530);
    }

    private int[,] GetInput()
    {
        string[] input = File.ReadAllLines("Day10\\input.txt");
        int rows = input.Length;
        int cols = input[0].Length;
        int[,] map = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                map[i, j] = input[i][j] - '0';
            }
        }

        return map;
    }
}
 