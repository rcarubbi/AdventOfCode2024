using FluentAssertions;

namespace AdventOfCode2024.Day11;

public class Solution
{
    public List<long> GetInput()
    {
        return File.ReadAllText("Day11\\input.txt").Split(' ').Select(long.Parse).ToList();
    }


    [Fact]
    public void Task1()
    {

        var initialStones = GetInput();

       
        const int blinks = 25;

        var rules = new List<ITransformationRule>
        {
            new ZeroToOneRule(),
            new SplitEvenDigitsRule(),
            new MultiplyBy2024Rule()
        };
        var ruleManager = new RuleManager(rules);
        var line = new Line(initialStones, ruleManager);
 
        for (int i = 0; i < blinks; i++)
        {
            line.Blink();
        }

        line.CountStones().Should().Be(202019);
        
    }

    [Fact]
    public void Task2()
    {

        var initialStones = GetInput();


        const int blinks = 75;

        var rules = new List<ITransformationRule>
        {
            new ZeroToOneRule(),
            new SplitEvenDigitsRule(),
            new MultiplyBy2024Rule()
        };
        var ruleManager = new RuleManager(rules);
        var line = new Line(initialStones, ruleManager);

        for (int i = 0; i < blinks; i++)
        {
            line.Blink();
        }

        line.CountStones().Should().Be(239_321_955_280_205);
    }
}
