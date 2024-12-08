namespace AdventOfCode2024.Day8;

public class ClassicAntinodeCalculator : IAntinodeCalculator
{
    public IEnumerable<(int X, int Y)> CalculateAntinodes(IEnumerable<Antenna> antennas)
    {
        var antennaList = antennas.ToList();
        var uniqueAntinodes = new HashSet<(int X, int Y)>();

        for (int i = 0; i < antennaList.Count; i++)
        {
            for (int j = i + 1; j < antennaList.Count; j++)
            {
                var a1 = antennaList[i];
                var a2 = antennaList[j];

                var dx = a2.Position.X - a1.Position.X;
                var dy = a2.Position.Y - a1.Position.Y;

                uniqueAntinodes.Add((a1.Position.X - dx, a1.Position.Y - dy));
                uniqueAntinodes.Add((a2.Position.X + dx, a2.Position.Y + dy));
            }
        }

        return uniqueAntinodes;
    }
}
