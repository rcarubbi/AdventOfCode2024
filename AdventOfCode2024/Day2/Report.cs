namespace AdventOfCode2024.Day2;

public class Report
{
    private readonly int[] _levels;

    public Report(int[] levels)
    {
        _levels = levels;
    }

    public int[] Levels => _levels;


    public bool IsAscendingSorted()
    {
        return _levels.SequenceEqual(_levels.Order());
    }

    public bool IsDescendingSorted()
    {
        return _levels.SequenceEqual(_levels.OrderDescending());
    }

    public bool AreAllGapsValid()
    {
        for (int i = 0; i < _levels.Length - 1; i++)
        {
            var gap = Math.Abs(_levels[i + 1] - _levels[i]);
            if (gap > 3 || gap < 1)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsSafe()
    {
        return (IsAscendingSorted() || IsDescendingSorted()) && AreAllGapsValid();
    }
}
