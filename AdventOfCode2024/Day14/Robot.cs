namespace AdventOfCode2024.Day14;

public class Robot
{
    public int PositionX { get; }
    public int PositionY { get; }
    public int VelocityX { get; }
    public int VelocityY { get; }

    public Robot(int positionX, int positionY, int velocityX, int velocityY)
    {
        PositionX = positionX;
        PositionY = positionY;
        VelocityX = velocityX;
        VelocityY = velocityY;
    }

    public (int X, int Y) CalculatePositionAfterSeconds(int seconds, int gridWidth, int gridHeight)
    {
        int newX = ((PositionX + VelocityX * seconds) % gridWidth + gridWidth) % gridWidth;
        int newY = ((PositionY + VelocityY * seconds) % gridHeight + gridHeight) % gridHeight;
        return (newX, newY);
    }
}
