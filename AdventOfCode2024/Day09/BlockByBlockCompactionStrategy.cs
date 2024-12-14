namespace AdventOfCode2024.Day09;

public class BlockByBlockCompactionStrategy : ICompactionStrategy
{
    public void Compact(Disk disk)
    {
        int freeIndex = disk.IndexOfFirstFreeSpace();

        while (freeIndex != -1 && disk.HasFileBlocksAfterFreeSpace(freeIndex))
        {
            int fileIndex = disk.IndexOfLastFileBlock();
            if (fileIndex == -1) break;

            disk.MoveBlock(fileIndex, freeIndex);
            freeIndex = disk.IndexOfFirstFreeSpace();
        }
    }
}
