using FluentAssertions;
using System.Runtime.Versioning;

namespace AdventOfCode2024.Day14;

public class Solution
{
    [Fact]
    public void Task1()
    {
        var robots = GetInput();

        var simulation = new Simulation();

        foreach (var robot in robots)
        {
            simulation.AddRobot(robot);
        }

        int safetyFactor = simulation.Run(100, 101, 103);

        safetyFactor.Should().Be(230686500);
    }

    const string OutputFolder = "robot_frames";

    [Fact]
    [SupportedOSPlatform("Windows")]
    public void Task2()
    {
        var robots = GetInput();

        var simulation = new Simulation();

        foreach (var robot in robots)
        {
            simulation.AddRobot(robot);
        }

     
        simulation.GenerateFrames(10000, 101, 103, OutputFolder);
        
        var earliestFrameWithSmallestSize = GetEarliesFrameWithSmallestSize(OutputFolder);

        earliestFrameWithSmallestSize.Should().Be(7672);

        TearDown();
    }

    private void TearDown()
    {
        Array.ForEach(Directory.GetFiles(OutputFolder), File.Delete);
    }

    private int GetEarliesFrameWithSmallestSize(string outputFolder)
    {
        // sort the png files by file size -- due to png compression, the smallest file with the least entropy is our tree!
        var outputFolderInfo = new DirectoryInfo(outputFolder);
        var frameFileNane = outputFolderInfo.GetFiles().OrderBy(x => x.Length).ThenBy(x => x.Name).ToList().First();
        return int.Parse(Path.GetFileNameWithoutExtension(frameFileNane.Name));
    }

    private List<Robot> GetInput()
    {
        var robots = new List<Robot>();
        var lines = File.ReadAllLines("Day14\\input.txt");

        foreach (var line in lines)
        {
            var parts = line.Split(new[] { "p=", " v=", "," }, StringSplitOptions.RemoveEmptyEntries);
            var positionX = int.Parse(parts[0]);
            var positionY = int.Parse(parts[1]);
            var velocityX = int.Parse(parts[2]);
            var velocityY = int.Parse(parts[3]);

            robots.Add(new Robot(positionX, positionY, velocityX, velocityY));
        }

        return robots;
    }
}
