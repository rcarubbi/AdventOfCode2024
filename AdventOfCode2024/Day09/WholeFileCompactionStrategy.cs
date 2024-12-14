using FluentAssertions;

namespace AdventOfCode2024.Day09;

public class WholeFileCompactionStrategy : ICompactionStrategy
{
    public void Compact(Disk disk)
    {
        var freeSpans = disk.FindFreeSpaceSpans();

        var fileIds = disk.Blocks
            .Where(block => !block.IsFree)
            .Select(block => block.Id)
            .Distinct()
            .OrderByDescending(id => id);

        foreach (var fileId in fileIds)
        {
            var fileBlocks = disk.Blocks
                .Select((block, index) => new { block, index })
                .Where(x => x.block.Id == fileId)
                .ToList();

            if (fileBlocks.Count == 0) continue;

            int start = fileBlocks.First().index;
            int length = fileBlocks.Count;

            foreach (var (spanStart, spanLength) in freeSpans)
            {
                if (spanLength >= length && spanStart < start)
                {
                    disk.MoveWholeFile(start, length, spanStart);
                    break;
                }
            }

            freeSpans = disk.FindFreeSpaceSpans();
        }
    }
}
