namespace AdventOfCode2024.Day11;

public class ZeroToOneRule : ITransformationRule
{
    public bool CanApply(long value) => value == 0;

    public IEnumerable<(long Value, long Count)> Apply(long value, long count)
    {
        yield return (1, count);
    }
}
