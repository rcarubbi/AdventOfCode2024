namespace AdventOfCode2024.Day5;

public partial class Solution
{
    public class PageOrderingValidator 
    {
        public bool IsValid(string[] updateNumbers, Dictionary<int, IEnumerable<int>> pageOrderingRulesMap)
        {
            for (int i = 0; i < updateNumbers.Length; i++)
            {
                var number = int.Parse(updateNumbers[i]);

                if (!pageOrderingRulesMap.TryGetValue(number, out var pagesAfter))
                    continue;

                for (int j = 0; j < i; j++)
                {
                    var previousNumber = int.Parse(updateNumbers[j]);
                    if (pagesAfter.Contains(previousNumber))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }


}
