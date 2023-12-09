namespace AdventOfCode.Day_8;

public class Maps
{
    public Maps(string leftRights, List<Map> mapItems)
    {
        LeftRights = leftRights;
        MapItems = mapItems;
        LinkedMapItems = new List<LinkedMap>();
        mapItems.ForEach(mi=>LinkedMapItems.Add(new LinkedMap(mi.Start,mi.Left,mi.Right)));
        var linkedMaps = LinkedMapItems.ToDictionary(kvp=>kvp.Start);
        LinkedMapItems.ForEach(mi => { mi.Left = linkedMaps[mi.LeftStr];mi.Right = linkedMaps[mi.RightStr];});
    }

    public string LeftRights { get; init; }
    public List<Map> MapItems { get; init; }
    private List<LinkedMap> LinkedMapItems { get; init; }
    
    public long Steps() => PathLength( LinkedMapItems.First( m => m.Start.Equals("AAA")));

    private IEnumerable<char> RepeatingCycle
    {
        get { return Enumerable.Repeat(LeftRights.ToArray(), 20000).SelectMany(s=>s); }
    }

    public long GhostSteps()
    {
        var allStarts = LinkedMapItems.Where(m => m.EndsWithA).ToArray();
      
        var allPaths = allStarts.Select(PathLength).ToArray();

        // this is only true if the path trough the links is balanced of the series of LeftRight combinations for all ghosts
        // if the Precess then only brute force would work
        return allPaths.Lcm();
    }

    private int PathLength( LinkedMap starting)
    {
        var count = 1;

        foreach (var c in RepeatingCycle)
        {
            starting = c == 'L' ? starting.Left : starting.Right;

            if (starting.EndsWithZ)
                return count;
            count++;
        }

        throw new Exception("Im not counting for ever");
    }
}