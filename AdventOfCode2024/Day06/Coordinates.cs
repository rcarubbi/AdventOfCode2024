namespace AdventOfCode2024.Day06;

record Coordinates(int X, int Y)
{

    public static Coordinates operator +(Coordinates a, Coordinates b) => new(a.X + b.X, a.Y + b.Y);

    public static Coordinates operator -(Coordinates a, Coordinates b) => new(a.X - b.X, a.Y - b.Y);
}
