using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.Versioning;

namespace AdventOfCode2024.Day14;

public class Simulation
{
    private readonly List<Robot> _robots = new();

    public void AddRobot(Robot robot)
    {
        _robots.Add(robot);
    }

    public int Run(int seconds, int gridWidth, int gridHeight)
    {
        int midX = gridWidth / 2;
        int midY = gridHeight / 2;

        var quadrants = new Dictionary<string, int>
        {
            { "TopLeft", 0 },
            { "TopRight", 0 },
            { "BottomLeft", 0 },
            { "BottomRight", 0 }
        };

        foreach (var robot in _robots)
        {
            var (newX, newY) = robot.CalculatePositionAfterSeconds(seconds, gridWidth, gridHeight);

           
            if (newX == midX || newY == midY) continue;

         
            if (newX < midX && newY < midY) quadrants["TopLeft"]++;
            else if (newX >= midX && newY < midY) quadrants["TopRight"]++;
            else if (newX < midX && newY >= midY) quadrants["BottomLeft"]++;
            else if (newX >= midX && newY >= midY) quadrants["BottomRight"]++;
        }

        return quadrants["TopLeft"] *
               quadrants["TopRight"] *
               quadrants["BottomLeft"] *
               quadrants["BottomRight"];
    }

    [SupportedOSPlatform("Windows")]
    public void GenerateFrames(int totalSeconds, int gridWidth, int gridHeight, string outputFolder)
    {
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        for (int t = 0; t <= totalSeconds; t++)
        {
            bool[,] grid = new bool[gridHeight, gridWidth];

           
            foreach (var robot in _robots)
            {
                var (x, y) = robot.CalculatePositionAfterSeconds(t, gridWidth, gridHeight);
                grid[y, x] = true;
            }

          
            GenerateFrameImage(grid, gridWidth, gridHeight, Path.Combine(outputFolder, $"{t:0000}.png"), t);
        }
    }

    [SupportedOSPlatform("Windows")]
    private void GenerateFrameImage(bool[,] grid, int gridWidth, int gridHeight, string filePath, int frameNumber)
    {
        int pixelSize = 10; 
        using Bitmap bitmap = new(gridWidth * pixelSize, gridHeight * pixelSize);

        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            graphics.Clear(Color.White);
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    if (grid[y, x])
                    {
                        graphics.FillRectangle(Brushes.Black, x * pixelSize, y * pixelSize, pixelSize, pixelSize);
                    }
                }
            }

          
            graphics.DrawRectangle(Pens.Black, 0, 0, bitmap.Width - 1, bitmap.Height - 1);

            
            string text = $"Time: {frameNumber}s";
            graphics.DrawString(text, new Font("Arial", 10), Brushes.Red, 5, 5);
        }

       
        bitmap.Save(filePath, ImageFormat.Png);
    }
}