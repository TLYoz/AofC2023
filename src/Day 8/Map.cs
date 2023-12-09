namespace AdventOfCode.Day_8;

public class Map
{
    public Map(string start, string left, string right)
    {
        Start = start;
        Left = left;
        Right = right;
    }

    public string Start { get; }
    public string Left { get; }
    public string Right { get; }
    
}