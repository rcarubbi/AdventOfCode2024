namespace AdventOfCode2024.Day10;

public class Trail
{
    public List<(int X, int Y)> Path { get; } = new();
    public HashSet<(int X, int Y)> ReachableNines { get; } = new();

    public Trail(IEnumerable<(int X, int Y)> path, HashSet<(int X, int Y)> reachableNines)
    {
        Path.AddRange(path);
        ReachableNines.UnionWith(reachableNines);
    }
}
 