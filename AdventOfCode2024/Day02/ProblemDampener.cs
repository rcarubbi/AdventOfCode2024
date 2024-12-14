namespace AdventOfCode2024.Day02;

public class ProblemDampener
{
    private readonly Report _report;

    public ProblemDampener(Report report)
    {
        _report = report;
    }

    public bool IsSafe()
    {
        for (int i = 0; i < _report.Levels.Length; i++)
        {
            var levels = _report.Levels.ToList();
            levels.RemoveAt(i);

            var report = new Report(levels.ToArray());
            if (report.IsSafe())
                return true;
        }

        return false;
    }
}
