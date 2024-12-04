namespace AdventOfCode2024.Day4;

public class WordSeeker
{
    private readonly string[] _grid;
    private readonly int _rows;
    private readonly int _cols;

    private readonly int[][] _directions = {
                [0, 1],  // Right
                [0, -1], // Left
                [1, 0],  // Down
                [-1, 0], // Up
                [1, 1],  // Down-Right
                [-1, -1],// Up-Left
                [1, -1], // Down-Left
                [-1, 1]  // Up-Right
            };

    public WordSeeker(string[] grid)
    {
        _grid = grid;
        _rows = _grid.Length;
        _cols = _grid[0].Length;
    }

    public int CountOccurrences(string word)
    {

        int wordLength = word.Length;
        int count = 0;

        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _cols; c++)
            {
                foreach (var dir in _directions)
                {
                    int dr = dir[0];
                    int dc = dir[1];
                    // Check if the word fits in the given direction
                    if (IsWordFound(word, r, c, dr, dc))
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    private bool IsWordFound(string word, int startRow, int startCol, int rowDir, int colDir)
    {
        int wordLength = word.Length;

        for (int i = 0; i < wordLength; i++)
        {
            int newRow = startRow + i * rowDir;
            int newCol = startCol + i * colDir;

            // Check boundaries
            if (newRow < 0 || newRow >= _rows || newCol < 0 || newCol >= _cols)
            {
                return false;
            }

            // Check character match
            if (_grid[newRow][newCol] != word[i])
            {
                return false;
            }
        }

        return true;
    }
}
