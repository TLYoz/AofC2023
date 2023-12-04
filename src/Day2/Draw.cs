namespace AdventOfCode.Day2;

public class Draw
{
    private readonly string[] _colouredGroups;
    
    // by using lazy and visiting the _colouredGroups on demand you can significantly reduce computation regret spend for the IsPossible case 
    private Draw(string[] colouredGroups)
    {
        _colouredGroups = colouredGroups;
        _blue = new Lazy<int>(()=> GetCount("blue"));
        _green = new Lazy<int>(()=> GetCount("green"));
        _red = new Lazy<int>(()=> GetCount("red"));
    }

    private int GetCount(string colour) => int.Parse(new string(_colouredGroups.FirstOrDefault(g => g.Contains(colour),"0").Where(char.IsNumber).ToArray()));

    public int Blue => _blue.Value;
    public int Red  => _red.Value;
    public int Green  => _green.Value;
    
    public bool IsPossible(Bag bag) => Blue <= bag.Blue && Red <= bag.Red && Green <= bag.Green;
    public static Draw Parse(string drawstring) => new(drawstring.Split(",",StringSplitOptions.RemoveEmptyEntries));
    
    private readonly Lazy<int> _blue;
    private readonly Lazy<int> _green;
    private readonly Lazy<int> _red;
}