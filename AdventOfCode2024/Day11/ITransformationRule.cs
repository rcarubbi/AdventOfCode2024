namespace AdventOfCode2024.Day11;

public interface ITransformationRule
{
    bool CanApply(long value);
    IEnumerable<(long Value, long Count)> Apply(long value, long count);
}
