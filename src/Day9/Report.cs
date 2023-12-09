namespace AdventOfCode.Day9;

public record Report(List<long> Sequence)
{
    public long NextValue => Sequence.Next();
    public long PreviousValue => Sequence.Previous();
    
}