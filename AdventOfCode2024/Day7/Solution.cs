
using FluentAssertions;
using System.Diagnostics;

namespace AdventOfCode2024.Day7;

public partial class Solution
{
    private static List<Equation> GetInput()
    {
        var equations = new List<Equation>();

        foreach (var line in File.ReadLines("Day7\\Input.txt"))
        {
            var parts = line.Split(":");
            long target = long.Parse(parts[0].Trim());
            int[] numbers = Array.ConvertAll(parts[1].Trim().Split(" "), int.Parse);

            equations.Add(new Equation(target, numbers));
        }

        return equations;
    }

    [Fact]
    public void Task1()
    {
        var equations = GetInput();

        var basicOperators = new List<IOperator>
        {
            new AdditionOperator(),
            new MultiplicationOperator()
        };


        var basicCalibrationSystem = new CalibrationSystem(equations, basicOperators);

        var basicTotal = basicCalibrationSystem.CalculateTotalCalibrationResult();
        basicTotal.Should().Be(5_030_892_084_481);
        Debug.WriteLine($"Day 7, Task 1 answer is: {basicTotal}");
    }



    [Fact]
    public void Task2()
    {
        var equations = GetInput();

        var advancedOperators = new List<IOperator>
        {
            new AdditionOperator(),
            new MultiplicationOperator(),
            new ConcatenationOperator()
        };

        var advancedCalibrationSystem = new CalibrationSystem(equations, advancedOperators);
        var advancedTotal = advancedCalibrationSystem.CalculateTotalCalibrationResult();

        advancedTotal.Should().Be(91_377_448_644_679);
        Debug.WriteLine($"Day 7, Task 2 answer is: {advancedTotal}");
    }


}

