namespace AdventOfCode.Day_8;

public class LinkedMap
{
    public LinkedMap(string start, string leftStr, string rightStr)
    {
        Start = start;
        LeftStr = leftStr;
        RightStr = rightStr;
        EndsWithA = start.EndsWith('A');
        EndsWithZ = start.EndsWith('Z');
    }
    
    public bool EndsWithA { get; }

    public bool EndsWithZ { get; }

    public string Start { get; }
    public string LeftStr { get; }
    public string RightStr { get; }

    public LinkedMap Left { get; set; }
    public LinkedMap Right { get; set; }

};