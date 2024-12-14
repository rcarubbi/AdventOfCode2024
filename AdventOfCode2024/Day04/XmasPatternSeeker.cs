namespace AdventOfCode2024.Day04;

public class XmasPatternSeeker
{
    private readonly string[] _grid;
    private readonly int _rows;
    private readonly int _cols;

    public XmasPatternSeeker(string[] grid)
    {
        _grid = grid;
        _rows = _grid.Length;
        _cols = _grid[0].Length;
    }

    public int CountOccurrences()
    {
        int count = 0;

        for (int r = 1; r < _rows - 1; r++) // Avoid edges
        {
            for (int c = 1; c < _cols - 1; c++) // Avoid edges
            {
                if (_grid[r][c] == 'A' && (
                    CheckDiagonal(r, c, 1, 1, 1, 1)
                    || CheckDiagonal(r, c, -1, -1, -1, -1)
                    || CheckDiagonal(r, c, 1, 1, -1, -1)
                    || CheckDiagonal(r, c, -1, -1, 1, 1)))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private bool CheckDiagonal(int centerRow, int centerCol, int dr1, int dc1, int dr2, int dc2)
    {
        // Top-left/bottom-right diagonal
        int mRow1f = centerRow - dr1, mCol1f = centerCol - dc1;
        int sRow1f = centerRow + dr1, sCol1f = centerCol + dc1;

        // Top-right/bottom-left diagonal
        int mRow2f = centerRow - dr2, mCol2f = centerCol + dc2;
        int sRow2f = centerRow + dr2, sCol2f = centerCol - dc2;


        return _grid[mRow1f][mCol1f] == 'M' &&
                 _grid[sRow1f][sCol1f] == 'S' &&
                 _grid[mRow2f][mCol2f] == 'M' &&
                 _grid[sRow2f][sCol2f] == 'S';
    }
}
