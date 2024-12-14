namespace AdventOfCode2024.Day08;

public interface IAntinodeCalculator
{
    IEnumerable<(int X, int Y)> CalculateAntinodes(IEnumerable<Antenna> antennas);
}
