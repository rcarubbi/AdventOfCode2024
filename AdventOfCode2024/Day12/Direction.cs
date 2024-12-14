namespace AdventOfCode2024.Day12;

public record Direction(int Row, int Col)
{
    public Direction TurnLeft() => new Direction(-Col, Row);
    public Direction TurnRight() => new Direction(Col, -Row);

    public static readonly Direction Up = new(-1, 0);
    public static readonly Direction Down = new(1, 0);
    public static readonly Direction Left = new(0, -1);
    public static readonly Direction Right = new(0, 1);
}


