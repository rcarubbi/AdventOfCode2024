namespace AdventOfCode2024.Day10;

public class TopographicMap
{
    public int[,] Heights { get; }
    public List<Trailhead> Trailheads { get; } = new();

    public TopographicMap(int[,] heights)
    {
        Heights = heights;
        FindTrailheads();
    }

    private void FindTrailheads()
    {
        for (int i = 0; i < Heights.GetLength(0); i++)
        {
            for (int j = 0; j < Heights.GetLength(1); j++)
            {
                if (Heights[i, j] == 0)
                {
                    Trailheads.Add(new Trailhead(this, i, j));
                }
            }
        }
    }
}
 