
using FluentAssertions;
using System.Diagnostics;

namespace AdventOfCode2024.Day01;

public class Solution
{
    private static (List<int> LocationIdsLeft, List<int> LocationIdsRight) GetInput()
    {
        var lines = File.ReadAllLines("Day01\\Input.txt");
        var locationIdsLeft = new List<int>();
        var locationIdsRight = new List<int>();

        foreach (var line in lines)
        {
            var values = line.Split("   ");
            locationIdsLeft.Add(int.Parse(values[0]));
            locationIdsRight.Add(int.Parse(values[1]));
        }

        return (locationIdsLeft, locationIdsRight);
    }


    [Fact]
    public void Task1()
    {
        var (locationIdsLeft, locationIdsRight) = GetInput();
         
        var distance = CalculateDistances(locationIdsLeft, locationIdsRight).Sum();

        distance.Should().Be(1603498);

        Debug.WriteLine($"Day 1, Task 1 answer is: {distance}");
    }

    [Fact]
    public void Task2()
    {
        var (locationIds1, locationIds2) = GetInput();

        var similarity = CalculateSimilarities(locationIds1, locationIds2).Sum();

        similarity.Should().Be(25574739);

        Debug.WriteLine($"Day 1, Task 2 answer is: {similarity}");
    }


    private static IEnumerable<int> CalculateSimilarities(List<int> LocationIdsLeft, List<int> LocationIdsRight)
    {
        var locationIdsRightFrequencyLookup = LocationIdsRight
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());

        foreach (var locationId in LocationIdsLeft)
        {
            if (locationIdsRightFrequencyLookup.TryGetValue(locationId, out var factor))
            {
                yield return locationId * factor;
            }
        }
    }


    private static IEnumerable<int> CalculateDistances(List<int> locationIdsLeft, List<int> locationIdsRight)
    {
        locationIdsLeft.Sort();
        locationIdsRight.Sort();

        for (int i = 0; i < locationIdsLeft.Count; i++)
        {
            yield return Math.Abs(locationIdsLeft[i] - locationIdsRight[i]);
        }
    }
}