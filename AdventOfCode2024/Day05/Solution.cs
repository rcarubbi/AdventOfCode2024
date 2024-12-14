using FluentAssertions;
using System.Diagnostics;

namespace AdventOfCode2024.Day05;

public partial class Solution
{
    public (string[] PageOrderingRules, string[] Updates) GetInput()
    {
        var content = File.ReadAllLines("Day05\\Input.txt");
        var pageOrderingRules = content.TakeWhile(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        var updates = content.SkipWhile(x => !string.IsNullOrWhiteSpace(x)).Skip(1).ToArray();
        return (pageOrderingRules, updates);
    }

    [Fact]
    public void Task1()
    {
        var (pageOrderingRules, updates) = GetInput();
        var validator = new PageOrderingValidator();
        var pageOrderingRulesMap = PageOrderingRuleParser.Parse(pageOrderingRules);
        var sum = updates
        .Select(update => update.Split(","))
            .Where(updateNumbers => validator.IsValid(updateNumbers, pageOrderingRulesMap))
            .Sum(UpdateProcessor.FindMiddle);

        Debug.WriteLine($"Day 5, Task 1 answer is: {sum}");
        sum.Should().Be(7074);
    }

    [Fact]
    public void Task2()
    {
        var (pageOrderingRules, updates) = GetInput();
        var pageOrderingRulesMap = PageOrderingRuleParser.Parse(pageOrderingRules);

        var validator = new PageOrderingValidator();
        var reorderer = new PageReorderer();
        var sum = updates
        .Select(update => update.Split(","))
            .Where(updateNumbers => !validator.IsValid(updateNumbers, pageOrderingRulesMap))
            .Select(updateNumbers => reorderer.Reorder(updateNumbers, pageOrderingRulesMap))
            .Sum(UpdateProcessor.FindMiddle);

        Debug.WriteLine($"Day 5, Task 2 answer is: {sum}");
        sum.Should().Be(4828);
    }


}
