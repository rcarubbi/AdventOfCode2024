namespace AdventOfCode2024.Day8;

public interface IAntinodeCalculator
{
    IEnumerable<(int X, int Y)> CalculateAntinodes(IEnumerable<Antenna> antennas);
}
