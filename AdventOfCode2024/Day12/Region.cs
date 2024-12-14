namespace AdventOfCode2024.Day12;

public class Region
{
    public char PlantType { get; }
    public HashSet<Node> Cells { get; }
    private readonly char[,] _map;
    private readonly int _gridSize;

    public int Area => Cells.Count;

    public Region(char plantType, char[,] map, int gridSize)
    {
        PlantType = plantType;
        Cells = new HashSet<Node>();
        _map = map;
        _gridSize = gridSize;
    }

    public void AddCell(Node node)
    {
        Cells.Add(node);
    }

    public int CalculatePerimeter()
    {
        int perimeter = 0;

        foreach (var node in Cells)
        {
            foreach (var dir in new[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left })
            {
                var neighborPos = node.Position.Move(dir);


                if (neighborPos.OutOfBounds(_gridSize) || Cells.All(n => n.Position != neighborPos))
                {
                    perimeter++;
                }
            }
        }

        return perimeter;
    }

    public int CalculateUniqueSides()
    {
        var outerPerimeter = new List<(Node Node, Direction Direction)>();

        foreach (var node in Cells)
        {
            foreach (var dir in new[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left })
            {
                var neighborPos = node.Position.Move(dir);
                var neighbor = node.Neighbors.FirstOrDefault(n => n.Position == neighborPos);

                if (neighbor == null || neighbor.Value != PlantType)
                {
                    outerPerimeter.Add((node, dir));
                }
            }
        }

        int sides = 0;

        while (outerPerimeter.Count > 0)
        {

            var (node, direction) = outerPerimeter[0];
            outerPerimeter.RemoveAt(0);


            WalkSide(direction.TurnLeft());
            WalkSide(direction.TurnRight());

            sides++;

            void WalkSide(Direction dir)
            {
                var nextPos = node.Position.Move(dir);
                var next = outerPerimeter.FirstOrDefault(n => n.Node.Position == nextPos && n.Direction == direction);

                while (next != default)
                {
                    outerPerimeter.Remove(next);
                    nextPos = next.Node.Position.Move(dir);
                    next = outerPerimeter.FirstOrDefault(n => n.Node.Position == nextPos && n.Direction == direction);
                }
            }
        }

        return sides;
    }
}


