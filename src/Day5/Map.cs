namespace AdventOfCode.Day5;

public class Map
{
    public List<MapEntry> Entries { get; } = new();

    public long SourceToDestination(long source)
    {
        var firstOrDefault = Entries.FirstOrDefault(me=> source>= me.SourceStart && source < me.SourceEnd);
        return  (firstOrDefault?.Delta ?? 0) + source;
    }
    public long DestinationToSource(long source)
    {
        var firstOrDefault = Entries.FirstOrDefault(me=> source>= me.SourceStart + me.Delta && source < me.SourceEnd + me.Delta);
        return  -(firstOrDefault?.Delta ?? 0) + source;
    }
}