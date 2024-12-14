namespace AdventOfCode2024.Day10;

public class Trailhead
{
    public (int X, int Y) Position { get; }
    private readonly TopographicMap _map;
    private List<Trail> _trails;

    public Trailhead(TopographicMap map, int x, int y)
    {
        _map = map;
        Position = (x, y);
    }

    public int Score
    {
        get
        {
            EnsureTrailsExplored();
            return _trails.SelectMany(trail => trail.ReachableNines).Distinct().Count();
        }
    }

    public int Rating
    {
        get
        {
            EnsureTrailsExplored();
            return _trails.Count;
        }
    }

    private void EnsureTrailsExplored()
    {
        if (_trails == null)
        {
            var trailFinder = new TrailFinder(_map, Position.X, Position.Y);
            _trails = trailFinder.FindAllTrails();
        }
    }
}
 