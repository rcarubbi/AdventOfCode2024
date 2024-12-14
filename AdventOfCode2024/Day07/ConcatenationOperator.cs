
namespace AdventOfCode2024.Day07;

class ConcatenationOperator : IOperator
{
    public long Apply(long left, long right) => long.Parse($"{left}{right}");
}

