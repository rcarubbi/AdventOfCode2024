namespace AdventOfCode2024.Day6;

internal class LoopDetector
{
    private readonly PathTracker pathTracker;

    public LoopDetector(PathTracker pathTracker)
    {
        this.pathTracker = pathTracker;
    }

    public int CountPossibleObstructionPositions()
    {
        var maze = pathTracker.Maze;
        var guardPosition = pathTracker.GetGuardPosition();
        var validPositions = new HashSet<Coordinates>();

        for (int i = 0; i < maze.Length; i++)
        {
            for (int j = 0; j < maze[i].Length; j++)
            {
                var position = new Coordinates(i, j);


                if (maze[i][j] == '#' || position == guardPosition)
                    continue;


                maze[i][j] = '#';


                if (WillCauseLoop(guardPosition))
                {
                    validPositions.Add(position);
                }


                maze[i][j] = '.';
            }
        }

        return validPositions.Count;
    }

    private bool WillCauseLoop(Coordinates startPosition)
    {
        var maze = pathTracker.Maze;
        var guardPosition = startPosition;
        var guardDirection = pathTracker.GetGuardDirection(guardPosition);

        var visitedStates = new HashSet<(Coordinates, Coordinates)>();

        while (true)
        {
            var state = (guardPosition, guardDirection);

            if (visitedStates.Contains(state))
                return true;

            visitedStates.Add(state);


            guardPosition = pathTracker.MoveGuard(guardPosition, guardDirection);


            if (pathTracker.HasCollided(guardPosition))
            {
                guardPosition = guardPosition - guardDirection;
                guardDirection = pathTracker.ChangeDirection(guardDirection);
            }


            if (guardPosition == null)
                return false;
        }
    }
}