namespace AdventOfCode2024.Day10;

public class TrailheadAnalyzer
{
    private readonly TopographicMap _map;

    public TrailheadAnalyzer(TopographicMap map)
    {
        _map = map;
    }

    public int CalculateTotalScore()
    {
        return _map.Trailheads.Sum(trailhead => trailhead.Score);
    }

    public int CalculateTotalRating()
    {
        return _map.Trailheads.Sum(trailhead => trailhead.Rating);
    }
}
 