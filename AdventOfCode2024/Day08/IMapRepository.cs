namespace AdventOfCode2024.Day08;

public interface IMapRepository
{
    IEnumerable<Antenna> GetAntennas(string[] map);
    bool IsWithinBounds((int X, int Y) position, int width, int height);
}
