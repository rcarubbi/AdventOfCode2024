namespace AdventOfCode2024.Day8;

public interface IMapRepository
{
    IEnumerable<Antenna> GetAntennas(string[] map);
    bool IsWithinBounds((int X, int Y) position, int width, int height);
}
