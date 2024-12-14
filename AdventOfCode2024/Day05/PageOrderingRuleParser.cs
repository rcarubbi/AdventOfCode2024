namespace AdventOfCode2024.Day05;

public partial class Solution
{
    public static class PageOrderingRuleParser
    {
        public static Dictionary<int, IEnumerable<int>> Parse(string[] pageOrderingRules)
        {
            return pageOrderingRules
                .Select(rule => new PageOrderingRule(rule))
                .GroupBy(rule => rule.PageBefore)
                .ToDictionary(group => group.Key, group => group.Select(rule => rule.PageAfter));
        }
    }


}
