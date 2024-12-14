namespace AdventOfCode2024.Day13;

public class ClawMachineSolver
{
    public (long TotalTokensSpent, int MachinesWon) Solve(IEnumerable<Machine> machines)
    {
        long totalTokensSpent = 0;
        int machinesWon = 0;

        foreach (var machine in machines)
        {
            var minimumTokensRequired = CalculateMinimumTokens(machine);

            if (minimumTokensRequired.HasValue)
            {
                totalTokensSpent += minimumTokensRequired.Value;
                machinesWon++;
            }
        }

        return (totalTokensSpent, machinesWon);
    }

    private const int ButtonACost = 3;
    private const int ButtonBCost = 1;

    private long? CalculateMinimumTokens(Machine machine)
    {
        long determinant = machine.ButtonAMoveX * machine.ButtonBMoveY - machine.ButtonAMoveY * machine.ButtonBMoveX;

        if (determinant == 0)
        {
            return null;
        }


        long determinantA = machine.PrizePositionX * machine.ButtonBMoveY - machine.PrizePositionY * machine.ButtonBMoveX;
        long determinantB = machine.ButtonAMoveX * machine.PrizePositionY - machine.ButtonAMoveY * machine.PrizePositionX;

        if (determinantA % determinant != 0 || determinantB % determinant != 0)
        {
            return null;
        }

        long buttonAPresses = determinantA / determinant;
        long buttonBPresses = determinantB / determinant;

        if (buttonAPresses < 0 || buttonBPresses < 0)
        {
            return null;
        }


        return buttonAPresses * ButtonACost + buttonBPresses * ButtonBCost;
    }
}