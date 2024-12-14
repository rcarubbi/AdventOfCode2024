namespace AdventOfCode2024.Day09;

public class Block
{
    public int Id { get; }
    public bool IsFree => Id == -1;

    private Block(int id)
    {
        Id = id;
    }

    public static Block FileBlock(int id) => new Block(id);
    public static Block FreeSpace() => new Block(-1);
}
