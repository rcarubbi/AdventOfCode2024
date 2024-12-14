namespace AdventOfCode2024.Day09;

public class DiskParser : IDiskParser
{
    public Disk Parse(string diskMap)
    {
        var blocks = new List<Block>();
        int fileId = 0;

        for (int i = 0; i < diskMap.Length; i += 2)
        {
            int fileLength = diskMap[i] - '0';
            int freeLength = (i + 1 < diskMap.Length) ? diskMap[i + 1] - '0' : 0;

            blocks.AddRange(Enumerable.Repeat(Block.FileBlock(fileId), fileLength));
            blocks.AddRange(Enumerable.Repeat(Block.FreeSpace(), freeLength));

            fileId++;
        }

        return new Disk(blocks);
    }
}
