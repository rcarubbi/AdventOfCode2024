
using FluentAssertions;

namespace AdventOfCode2024.Day10;

public class TrailFinder
{
    private readonly TopographicMap _map;
    private readonly (int X, int Y) _startPosition;
    private readonly List<(int X, int Y)> _directions = new()
    {
        (0, 1),  // Right
        (1, 0),  // Down
        (0, -1), // Left
        (-1, 0)  // Up
    };

    public TrailFinder(TopographicMap map, int startX, int startY)
    {
        _map = map;
        _startPosition = (startX, startY);
    }

    public List<Trail> FindAllTrails()
    {
        var trails = new HashSet<string>(); // Guarda trilhas únicas com chave de caminho completo
        var stack = new Stack<(List<(int X, int Y)> path, int height)>();
        stack.Push((new List<(int X, int Y)> { _startPosition }, 0));

        while (stack.Count > 0)
        {
            var (path, height) = stack.Pop();
            var current = path.Last();

            foreach (var (dx, dy) in _directions)
            {
                int newX = current.X + dx;
                int newY = current.Y + dy;

                if (IsValidMove(current.X, current.Y, newX, newY) && !path.Contains((newX, newY)))
                {
                    var newPath = new List<(int X, int Y)>(path) { (newX, newY) };
                    int newHeight = _map.Heights[newX, newY];

                    if (newHeight == 9)
                    {
                        
                        var pathKey = string.Join("->", newPath.Select(p => $"{p.X},{p.Y}"));
                        trails.Add(pathKey);
                    }
                    else
                    {
                        stack.Push((newPath, newHeight));
                    }
                }
            }
        }

        
        return trails.Select(pathKey =>
        {
            var path = pathKey.Split("->")
                              .Select(coord =>
                              {
                                  var parts = coord.Split(',');
                                  return (X: int.Parse(parts[0]), Y: int.Parse(parts[1]));
                              }).ToList();

            var reachableNines = new HashSet<(int X, int Y)>(path.Where(p => _map.Heights[p.X, p.Y] == 9));
            return new Trail(path, reachableNines);
        }).ToList();
    }

    private bool IsValidMove(int currentX, int currentY, int newX, int newY)
    {
        return newX >= 0 && newX < _map.Heights.GetLength(0) &&
               newY >= 0 && newY < _map.Heights.GetLength(1) &&
               _map.Heights[newX, newY] == _map.Heights[currentX, currentY] + 1;
    }
}
 