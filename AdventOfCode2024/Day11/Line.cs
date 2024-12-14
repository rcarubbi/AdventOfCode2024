namespace AdventOfCode2024.Day11;

public class Line
{
    private Dictionary<long, long> Stones; // Mapeia valor para contagem
    private readonly RuleManager _ruleManager;

    public Line(IEnumerable<long> initialValues, RuleManager ruleManager)
    {
        Stones = new Dictionary<long, long>();
        foreach (var value in initialValues)
        {
            if (!Stones.ContainsKey(value))
                Stones[value] = 0;
            Stones[value]++;
        }
        _ruleManager = ruleManager;
    }

    public void Blink()
    {
        var newStones = new Dictionary<long, long>();
        foreach (var (value, count) in Stones)
        {
            foreach (var (newValue, newCount) in _ruleManager.ApplyRules(value, count))
            {
                if (!newStones.ContainsKey(newValue))
                    newStones[newValue] = 0;
                newStones[newValue] += newCount;
            }
        }
        Stones = newStones;
    }

    public long CountStones() => Stones.Values.Sum();

    public override string ToString()
    {
        return string.Join(", ", Stones);
    }
}