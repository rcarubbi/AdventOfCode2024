namespace AdventOfCode2024.Day08;

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
