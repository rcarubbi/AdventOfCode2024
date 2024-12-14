namespace AdventOfCode2024.Day09;

public class Disk
{
    private readonly List<Block> _blocks;

    public Disk(IEnumerable<Block> blocks)
    {
        _blocks = blocks.ToList();
    }

    public IReadOnlyList<Block> Blocks => _blocks;

    public int IndexOfFirstFreeSpace()
    {
        return _blocks.FindIndex(block => block.IsFree);
    }

    public int IndexOfLastFileBlock()
    {
        for (int i = _blocks.Count - 1; i >= 0; i--)
        {
            if (!_blocks[i].IsFree)
            {
                return i;
            }
        }
        return -1;
    }

    public bool HasFileBlocksAfterFreeSpace(int freeIndex)
    {
        for (int i = freeIndex + 1; i < _blocks.Count; i++)
        {
            if (!_blocks[i].IsFree)
            {
                return true;
            }
        }
        return false;
    }

    public void MoveBlock(int sourceIndex, int destinationIndex)
    {
        _blocks[destinationIndex] = _blocks[sourceIndex];
        _blocks[sourceIndex] = Block.FreeSpace();
    }

    public void MoveWholeFile(int startIndex, int length, int destinationIndex)
    {
        for (int i = 0; i < length; i++)
        {
            _blocks[destinationIndex + i] = _blocks[startIndex + i];
            _blocks[startIndex + i] = Block.FreeSpace();
        }
    }

    public List<(int Start, int Length)> FindFreeSpaceSpans()
    {
        var spans = new List<(int Start, int Length)>();
        int start = -1;

        for (int i = 0; i < _blocks.Count; i++)
        {
            if (_blocks[i].IsFree)
            {
                if (start == -1) start = i;
            }
            else if (start != -1)
            {
                spans.Add((start, i - start));
                start = -1;
            }
        }

        if (start != -1) spans.Add((start, _blocks.Count - start));
        return spans;
    }
}
