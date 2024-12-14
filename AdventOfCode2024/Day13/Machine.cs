

namespace AdventOfCode2024.Day13;

public class Machine
{
    public int ButtonAMoveX { get; }
    public int ButtonAMoveY { get; }
    public int ButtonBMoveX { get; }
    public int ButtonBMoveY { get; }
    public long PrizePositionX { get; private set; }
    public long PrizePositionY { get; private set; }

    public Machine(int buttonAMoveX, int buttonAMoveY, int buttonBMoveX, int buttonBMoveY, long prizePositionX, long prizePositionY)
    {
        ButtonAMoveX = buttonAMoveX;
        ButtonAMoveY = buttonAMoveY;
        ButtonBMoveX = buttonBMoveX;
        ButtonBMoveY = buttonBMoveY;
        PrizePositionX = prizePositionX;
        PrizePositionY = prizePositionY;
    }

    public void AdjustPrizePosition(long offsetX, long offsetY)
    {
        PrizePositionX += offsetX;
        PrizePositionY += offsetY;
    }
}
