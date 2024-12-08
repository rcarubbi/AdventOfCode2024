namespace AdventOfCode2024.Day8;

public class AntinodeCounter
{
    private readonly IAntinodeCalculator _antinodesCalculator;
    private readonly IMapRepository _mapRepository;

    public AntinodeCounter(IMapRepository mapRepository, IAntinodeCalculator antinodesCalculator)
    {
        _antinodesCalculator = antinodesCalculator;
        _mapRepository = mapRepository;
    }

    public int CountUniqueAntinodes(string[] map)
    {
        var antennas = _mapRepository.GetAntennas(map).GroupBy(a => a.Frequency);
        var uniqueAntinodes = new HashSet<(int X, int Y)>();

        foreach (var group in antennas)
        {
            var antinodes = _antinodesCalculator.CalculateAntinodes(group);

            foreach (var antinode in antinodes)
            {
                if (_mapRepository.IsWithinBounds(antinode, map.Length, map[0].Length))
                {
                    uniqueAntinodes.Add(antinode);
                }
            }
        }

        return uniqueAntinodes.Count;
    }
}