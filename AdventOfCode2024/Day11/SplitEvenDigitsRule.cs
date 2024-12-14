namespace AdventOfCode2024.Day11;

public class SplitEvenDigitsRule : ITransformationRule
{
    public bool CanApply(long value)
    {
        return value.ToString().Length % 2 == 0;
    }

    public IEnumerable<(long Value, long Count)> Apply(long value, long count)
    {
        string valueStr = value.ToString();
        int mid = valueStr.Length / 2;
        long left = long.Parse(valueStr.Substring(0, mid));
        long right = long.Parse(valueStr.Substring(mid));
        yield return (left, count);
        yield return (right, count);
    }
}
