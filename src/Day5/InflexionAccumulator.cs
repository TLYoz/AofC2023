namespace AdventOfCode.Day5;

public record InflexionAccumulator(IEnumerable<Map> xs, IEnumerable<long> AccumulatedInflexions)
{
    // this is the closest I can can get to folding through the Maps 
    // this Accumulator starts with the out maps and works inwards 
    // generating inflexions mapped back to seeds from all Map inflexions 
    public InflexionAccumulator Next(Map x) =>
        new(xs.Skip(1), AccumulatedInflexions.Concat(x.Entries.Select(e=>e.SourceStart).Select(source =>
            xs.Aggregate(source, (destination, map) => map.DestinationToSource(destination)))));
}