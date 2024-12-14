namespace AdventOfCode2024.Day11;

public class RuleManager
{
    private readonly List<ITransformationRule> _rules;

    public RuleManager(IEnumerable<ITransformationRule> rules)
    {
        _rules = new List<ITransformationRule>(rules);
    }

    public IEnumerable<(long Value, long Count)> ApplyRules(long value, long count)
    {
        foreach (var rule in _rules)
        {
            if (rule.CanApply(value))
            {
                return rule.Apply(value, count);
            }
        }
        return Array.Empty<(long, long)>();
    }
}
