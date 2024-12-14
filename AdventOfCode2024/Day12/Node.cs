namespace AdventOfCode2024.Day12;

public record Node(char Value, Position Position, HashSet<Node> Neighbors)
{
    public void AddNeighbor(Node neighbor) => Neighbors.Add(neighbor);
}


