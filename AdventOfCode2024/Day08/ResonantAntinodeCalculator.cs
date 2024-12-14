namespace AdventOfCode2024.Day08;

public class ResonantAntinodeCalculator : IAntinodeCalculator
{
    private readonly int _mapWidth;
    private readonly int _mapHeight;

    public ResonantAntinodeCalculator(int mapWidth, int mapHeight)
    {
        _mapWidth = mapWidth;
        _mapHeight = mapHeight;
    }

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

                // Calcular o GCD para determinar os passos
                var gcd = GCD(Math.Abs(dx), Math.Abs(dy));
                var stepX = dx / gcd;
                var stepY = dy / gcd;

                // Estender para ambas as direções até os limites do mapa
                ExtendLineToBounds(a1.Position, stepX, stepY, uniqueAntinodes);
                ExtendLineToBounds(a2.Position, -stepX, -stepY, uniqueAntinodes);
            }
        }

        // Adicionar as próprias antenas
        foreach (var antenna in antennaList)
        {
            uniqueAntinodes.Add(antenna.Position);
        }

        return uniqueAntinodes;
    }

    private void ExtendLineToBounds((int X, int Y) start, int stepX, int stepY, HashSet<(int X, int Y)> antinodes)
    {
        int currentX = start.X;
        int currentY = start.Y;

        // Avançar para frente até os limites do mapa
        while (IsWithinBounds(currentX, currentY))
        {
            antinodes.Add((currentX, currentY));
            currentX += stepX;
            currentY += stepY;
        }
    }

    private bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x < _mapWidth && y >= 0 && y < _mapHeight;
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
