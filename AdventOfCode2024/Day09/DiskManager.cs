namespace AdventOfCode2024.Day09;

public class DiskManager
{
    private readonly IDiskParser _parser;
    private readonly IChecksumCalculator _checksumCalculator;

    public DiskManager(IDiskParser parser, IChecksumCalculator checksumCalculator)
    {
        _parser = parser;
        _checksumCalculator = checksumCalculator;
    }

    public long ProcessDisk(string diskMap, ICompactionStrategy compactionStrategy)
    {
        var disk = _parser.Parse(diskMap);
        compactionStrategy.Compact(disk);
        return _checksumCalculator.CalculateChecksum(disk);
    }
}