namespace AdventOfCode2024.Day12;

public record Position(int Row, int Col)
{
    public Position Move(Direction dir) => new Position(Row + dir.Row, Col + dir.Col);

    public bool OutOfBounds(int gridSize)
    {
        return Row < 0 || Row >= gridSize || Col < 0 || Col >= gridSize;
    }
}


