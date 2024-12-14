namespace AdventOfCode2024.Day12;

public class Map
{
    private readonly char[,] _map;
    private readonly int _gridSize;
    private readonly Node[,] _nodes;

    public Map(char[,] map)
    {
        _map = map;
        _gridSize = map.GetLength(0);
        _nodes = new Node[_gridSize, _gridSize];
    }

    public List<Region> IdentifyRegions()
    {
        BuildNodeGraph();
        var regions = new List<Region>();
        var visited = new HashSet<Node>();

        foreach (var node in _nodes)
        {
            if (node != null && !visited.Contains(node))
            {
                var region = ExploreRegion(node, visited);
                regions.Add(region);
            }
        }

        return regions;
    }

    private void BuildNodeGraph()
    {
        for (int row = 0; row < _gridSize; row++)
        {
            for (int col = 0; col < _gridSize; col++)
            {
                _nodes[row, col] = new Node(_map[row, col], new Position(row, col), new HashSet<Node>());
            }
        }

        for (int row = 0; row < _gridSize; row++)
        {
            for (int col = 0; col < _gridSize; col++)
            {
                foreach (var dir in new[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left })
                {
                    var neighborPos = new Position(row, col).Move(dir);
                    if (!neighborPos.OutOfBounds(_gridSize))
                    {
                        _nodes[row, col].AddNeighbor(_nodes[neighborPos.Row, neighborPos.Col]);
                    }
                }
            }
        }
    }

    private Region ExploreRegion(Node startNode, HashSet<Node> visited)
    {
        var region = new Region(startNode.Value, _map, _gridSize);
        var stack = new Stack<Node>();
        stack.Push(startNode);
        visited.Add(startNode);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            region.AddCell(node);

            foreach (var neighbor in node.Neighbors)
            {
                if (!visited.Contains(neighbor) && neighbor.Value == startNode.Value)
                {
                    stack.Push(neighbor);
                    visited.Add(neighbor);
                }
            }
        }

        return region;
    }
}


