namespace AdventOfCode2024.Day09;

public class ChecksumCalculator : IChecksumCalculator
{
    public long CalculateChecksum(Disk disk)
    {
        long checksum = 0;

        for (int i = 0; i < disk.Blocks.Count; i++)
        {
            if (!disk.Blocks[i].IsFree)
            {
                checksum += (long)i * disk.Blocks[i].Id;
            }
        }

        return checksum;
    }
}
