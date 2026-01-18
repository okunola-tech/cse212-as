/// <summary>
/// Maze class using dictionary mapping: (x,y) => [left, right, up, down]
/// Throws "Can't go that way!" if movement blocked or outside maze.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var dirs) || !dirs[0])
            throw new InvalidOperationException("Can't go that way!");
        _currX--;
    }

    public void MoveRight()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var dirs) || !dirs[1])
            throw new InvalidOperationException("Can't go that way!");
        _currX++;
    }

    public void MoveUp()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var dirs) || !dirs[2])
            throw new InvalidOperationException("Can't go that way!");
        _currY--; // Y decreases when moving up
    }

    public void MoveDown()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var dirs) || !dirs[3])
            throw new InvalidOperationException("Can't go that way!");
        _currY++; // Y increases when moving down
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
