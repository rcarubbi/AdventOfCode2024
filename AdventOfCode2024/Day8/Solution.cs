using FluentAssertions;
using System.Diagnostics;

namespace AdventOfCode2024.Day8;

public class Solution
{
    private static string[] GetInput()
    {
        var content = File.ReadAllLines("Day8\\Input.txt");

        return content;
    }

    [Fact]
    public async Task Task1()
    {
        var map = GetInput();
        var calculator = new AntinodeCalculator();
        var repository = new MapRepository();
        var counter = new AntinodeCounter(calculator, repository);

        int result = counter.CountUniqueAntinodes(map);
        result.Should().Be(289);
        Debug.WriteLine($"Day 8, Task 1 answer is: {result}");
    }
}

public record Antenna(char Frequency, (int X, int Y) Position);

public interface IAntinodeCalculator
{
    IEnumerable<(int X, int Y)> CalculateAntinodes(Antenna a1, Antenna a2);
}


public class AntinodeCalculator : IAntinodeCalculator
{
    public IEnumerable<(int X, int Y)> CalculateAntinodes(Antenna a1, Antenna a2)
    {
        var dx = a2.Position.X - a1.Position.X;
        var dy = a2.Position.Y - a1.Position.Y;

         
        var antinode1 = (a1.Position.X - dx, a1.Position.Y - dy);

      
        var antinode2 = (a2.Position.X + dx, a2.Position.Y + dy);

   
        yield return antinode1;
        yield return antinode2;
    }
}

public interface IMapRepository
{
    IEnumerable<Antenna> GetAntennas(string[] map);
    bool IsWithinBounds((int X, int Y) position, int width, int height);
}
public class MapRepository : IMapRepository
{
    public IEnumerable<Antenna> GetAntennas(string[] map)
    {
        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                char cell = map[y][x];
                if (char.IsLetterOrDigit(cell))
                    yield return new Antenna(cell, (x, y));
            }
        }
    }

    public bool IsWithinBounds((int X, int Y) position, int width, int height)
    {
        return position.X >= 0 && position.X < width &&
               position.Y >= 0 && position.Y < height;
    }
}
public class AntinodeCounter
{
    private readonly IAntinodeCalculator _antinodeCalculator;
    private readonly IMapRepository _mapRepository;

    public AntinodeCounter(IAntinodeCalculator antinodeCalculator, IMapRepository mapRepository)
    {
        _antinodeCalculator = antinodeCalculator;
        _mapRepository = mapRepository;
    }

    public int CountUniqueAntinodes(string[] map)
    {
        var antennas = _mapRepository.GetAntennas(map).GroupBy(a => a.Frequency);
        var uniqueAntinodes = new HashSet<(int X, int Y)>();

        foreach (var group in antennas)
        {
            var antennaList = group.ToList();

            for (int i = 0; i < antennaList.Count; i++)
            {
                for (int j = i + 1; j < antennaList.Count; j++)
                {
                    var antinodes = _antinodeCalculator.CalculateAntinodes(antennaList[i], antennaList[j]);

                    foreach (var antinode in antinodes)
                    {
                        if (_mapRepository.IsWithinBounds(antinode, map[0].Length, map.Length))
                        {
                            uniqueAntinodes.Add(antinode);
                        }
                    }
                }
            }
        }

        return uniqueAntinodes.Count;
    }
}
