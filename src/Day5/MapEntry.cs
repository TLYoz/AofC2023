namespace AdventOfCode.Day5;

public record MapEntry(long SourceStart, long SourceEnd, long Delta)
{
    public static MapEntry Parse(string line)
    {
        var split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var source = long.Parse(split[1]);
        var destination = long.Parse(split[0]);
        var length = long.Parse(split[2]);
        return new MapEntry(source,source+length,destination-source);
    }
}