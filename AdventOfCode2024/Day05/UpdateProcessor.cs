namespace AdventOfCode2024.Day05;

public partial class Solution
{
    public static class UpdateProcessor
    {
        public static int FindMiddle(string[] updateNumbers)
        {
            var middleIndex = updateNumbers.Length / 2;
            return int.Parse(updateNumbers[middleIndex]);
        }
    }


}
