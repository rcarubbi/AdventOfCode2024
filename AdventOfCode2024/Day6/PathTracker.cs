namespace AdventOfCode2024.Day6;

internal class PathTracker
{
    private char[][] maze;

    public PathTracker(char[][] maze)
    {
        this.maze = maze;
    }

    const char GuardUp = '^';
    const char GuardDown = 'v';
    const char GuardLeft = '<';
    const char GuardRight = '>';

    private Coordinates Up = new(-1, 0);
    private Coordinates Down = new(1, 0);
    private Coordinates Left = new(0, -1);
    private Coordinates Right = new(0, 1);
    public char[][] Maze => maze;

    public int CountGuardDistinctPositions()
    {
        HashSet<Coordinates> history = new();

        var guardPosition = GetGuardPosition();
        history.Add(guardPosition);
        var guardDirection = GetGuardDirection(guardPosition);

        while (guardPosition != null)
        {
            guardPosition = MoveGuard(guardPosition, guardDirection);

            if (HasCollided(guardPosition))
            {
                guardPosition = guardPosition - guardDirection;
                guardDirection = ChangeDirection(guardDirection);
            }
            else if (guardPosition != null)
            {
                history.Add(guardPosition);
            }
        }

        return history.Count;
    }

    public bool HasCollided(Coordinates? guardPosition)
    {
        return guardPosition != null && maze[guardPosition.X][guardPosition.Y] == '#';
    }

    public Coordinates? MoveGuard(Coordinates guardPosition, Coordinates guardDirection)
    {
        var newPosition = guardPosition + guardDirection;
        if (newPosition.X < 0 || newPosition.X >= maze.Length || newPosition.Y < 0 || newPosition.Y >= maze[0].Length)
        {
            return null;
        }
        return newPosition;
    }

    public Coordinates ChangeDirection(Coordinates guardDirection)
    {
        if (guardDirection == Up)
        {
            return Right;
        }
        if (guardDirection == Right)
        {
            return Down;
        }
        if (guardDirection == Down)
        {
            return Left;
        }
        if (guardDirection == Left)
        {
            return Up;
        }
        throw new Exception("Invalid direction");
    }

    public Coordinates GetGuardDirection(Coordinates guardPosition)
    {
        if (maze[guardPosition.X][guardPosition.Y] == GuardUp)
        {
            return Up;
        }
        if (maze[guardPosition.X][guardPosition.Y] == GuardDown)
        {
            return Down;
        }
        if (maze[guardPosition.X][guardPosition.Y] == GuardLeft)
        {
            return Left;
        }
        if (maze[guardPosition.X][guardPosition.Y] == GuardRight)
        {
            return Right;
        }
        throw new Exception("Invalid guard direction");
    }

    public Coordinates GetGuardPosition()
    {
        for (int i = 0; i < maze.Length; i++)
        {
            for (int j = 0; j < maze[i].Length; j++)
            {
                if (maze[i][j] == GuardUp || maze[i][j] == GuardDown || maze[i][j] == GuardLeft || maze[i][j] == GuardRight)
                {
                    return new Coordinates(i, j);
                }
            }
        }
        throw new Exception("Guard not found");
    }
}
