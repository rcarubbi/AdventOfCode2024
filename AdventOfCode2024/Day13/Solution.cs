using FluentAssertions;


namespace AdventOfCode2024.Day13;

public class Solution
{
    [Fact]
    public void Tasl1()
    {
        var machines = GetInput(); 
        var clawMachineSolver = new ClawMachineSolver();
        var (totalTokensSpent, machinesWon) = clawMachineSolver.Solve(machines);

        totalTokensSpent.Should().Be(28262);
    }

    private IEnumerable<Machine> GetInput()
    {
        var lines = File.ReadAllLines("Day13\\input.txt");
        var machines = new List<Machine>();
        int i = 0;
        while (i < lines.Length)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                i++;
                continue;
            }
 
            var buttonALine = lines[i++].Split(new[] { "X+", ", Y+" }, StringSplitOptions.None);
            int buttonAMoveX = int.Parse(buttonALine[1]);
            int buttonAMoveY = int.Parse(buttonALine[2]);

            
            var buttonBLine = lines[i++].Split(new[] { "X+", ", Y+" }, StringSplitOptions.None);
            int buttonBMoveX = int.Parse(buttonBLine[1]);
            int buttonBMoveY = int.Parse(buttonBLine[2]);

            
            var prizeLine = lines[i++].Split(new[] { "X=", ", Y=" }, StringSplitOptions.None);
            int prizePositionX = int.Parse(prizeLine[1]);
            int prizePositionY = int.Parse(prizeLine[2]);

            machines.Add(new Machine(buttonAMoveX, buttonAMoveY, buttonBMoveX, buttonBMoveY, prizePositionX, prizePositionY));
        }

        return machines;
    }

    [Fact]
    public void Task2()
    {
        var machines = GetInput();
        foreach (var machine in machines)
        {
            machine.AdjustPrizePosition(10000000000000, 10000000000000);
        }
 
        var clawMachineSolver = new ClawMachineSolver();
        var (totalTokensSpent, machinesWon) = clawMachineSolver.Solve(machines);
        totalTokensSpent.Should().Be(101_406_661_266_314);
    }
}
