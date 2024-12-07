namespace AdventOfCode2024.Day5;

public partial class Solution
{
    public class PageOrderingRule
    {
        public int PageBefore { get; }
        public int PageAfter { get; }

        public PageOrderingRule(string pair)
        {
            var items = pair.Split("|");
            PageBefore = int.Parse(items[0]);
            PageAfter = int.Parse(items[1]);
        }
    }


}
