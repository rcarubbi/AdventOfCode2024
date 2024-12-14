namespace AdventOfCode2024.Day11;

public class MultiplyBy2024Rule : ITransformationRule
{
    public bool CanApply(long value) => true;

    public IEnumerable<(long Value, long Count)> Apply(long value, long count)
    {
        yield return (value * 2024, count);
    }
}
