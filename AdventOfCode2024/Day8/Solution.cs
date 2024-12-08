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


public record Antenna(char Frequency, (int X, int Y) Position);

public interface IAntinodeCalculator
{
    IEnumerable<(int X, int Y)> CalculateAntinodes(IEnumerable<Antenna> antennas);
}


public class ClassicAntinodeCalculator : IAntinodeCalculator
{
    public IEnumerable<(int X, int Y)> CalculateAntinodes(IEnumerable<Antenna> antennas)
    {
        var antennaList = antennas.ToList();
        var uniqueAntinodes = new HashSet<(int X, int Y)>();

        for (int i = 0; i < antennaList.Count; i++)
        {
            for (int j = i + 1; j < antennaList.Count; j++)
            {
                var a1 = antennaList[i];
                var a2 = antennaList[j];

                var dx = a2.Position.X - a1.Position.X;
                var dy = a2.Position.Y - a1.Position.Y;

                uniqueAntinodes.Add((a1.Position.X - dx, a1.Position.Y - dy));
                uniqueAntinodes.Add((a2.Position.X + dx, a2.Position.Y + dy));
            }
        }

        return uniqueAntinodes;
    }
}
public class ResonantAntinodeCalculator : IAntinodeCalculator
{
    private readonly int _mapWidth;
    private readonly int _mapHeight;

    public ResonantAntinodeCalculator(int mapWidth, int mapHeight)
    {
        _mapWidth = mapWidth;
        _mapHeight = mapHeight;
    }

    public IEnumerable<(int X, int Y)> CalculateAntinodes(IEnumerable<Antenna> antennas)
    {
        var antennaList = antennas.ToList();
        var uniqueAntinodes = new HashSet<(int X, int Y)>();

        for (int i = 0; i < antennaList.Count; i++)
        {
            for (int j = i + 1; j < antennaList.Count; j++)
            {
                var a1 = antennaList[i];
                var a2 = antennaList[j];

                var dx = a2.Position.X - a1.Position.X;
                var dy = a2.Position.Y - a1.Position.Y;

                // Calcular o GCD para determinar os passos
                var gcd = GCD(Math.Abs(dx), Math.Abs(dy));
                var stepX = dx / gcd;
                var stepY = dy / gcd;

                // Estender para ambas as direções até os limites do mapa
                ExtendLineToBounds(a1.Position, stepX, stepY, uniqueAntinodes);
                ExtendLineToBounds(a2.Position, -stepX, -stepY, uniqueAntinodes);
            }
        }

        // Adicionar as próprias antenas
        foreach (var antenna in antennaList)
        {
            uniqueAntinodes.Add(antenna.Position);
        }

        return uniqueAntinodes;
    }

    private void ExtendLineToBounds((int X, int Y) start, int stepX, int stepY, HashSet<(int X, int Y)> antinodes)
    {
        int currentX = start.X;
        int currentY = start.Y;

        // Avançar para frente até os limites do mapa
        while (IsWithinBounds(currentX, currentY))
        {
            antinodes.Add((currentX, currentY));
            currentX += stepX;
            currentY += stepY;
        }
    }

    private bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x < _mapWidth && y >= 0 && y < _mapHeight;
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}


public interface IMapRepository
{
    IEnumerable<Antenna> GetAntennas(string[] map);
    bool IsWithinBounds((int X, int Y) position, int width, int height);
}
public class MapRepository : IMapRepository
{
    private int _mapWidth;
    private int _mapHeight;

    public MapRepository()
    {
        _mapWidth = 0;
        _mapHeight = 0;
    }

    public IEnumerable<Antenna> GetAntennas(string[] map)
    {
        _mapHeight = map.Length;
        _mapWidth = map[0].Length;

        for (int y = 0; y < _mapHeight; y++)
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                char cell = map[y][x];
                if (char.IsLetterOrDigit(cell))
                    yield return new Antenna(cell, (x, y));
            }
        }
    }

    public bool IsWithinBounds((int X, int Y) position, int width, int height)
    {
        return position.X >= 0 && position.X < _mapWidth &&
               position.Y >= 0 && position.Y < _mapHeight;
    }

    public int GetMapWidth() => _mapWidth;
    public int GetMapHeight() => _mapHeight;
}
public class AntinodeCounter
{
    private readonly IAntinodeCalculator _antinodesCalculator;
    private readonly IMapRepository _mapRepository;

    public AntinodeCounter(IMapRepository mapRepository, IAntinodeCalculator antinodesCalculator)
    {
        _antinodesCalculator = antinodesCalculator;
        _mapRepository = mapRepository;
    }

    public int CountUniqueAntinodes(string[] map)
    {
        var antennas = _mapRepository.GetAntennas(map).GroupBy(a => a.Frequency);
        var uniqueAntinodes = new HashSet<(int X, int Y)>();

        foreach (var group in antennas)
        {
            var antinodes = _antinodesCalculator.CalculateAntinodes(group);

            foreach (var antinode in antinodes)
            {
                if (_mapRepository.IsWithinBounds(antinode, map.Length, map[0].Length))
                {
                    uniqueAntinodes.Add(antinode);
                }
            }
        }

        return uniqueAntinodes.Count;
    }
}