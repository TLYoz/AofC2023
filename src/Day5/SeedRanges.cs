namespace AdventOfCode.Day5;

public class SeedRanges
{
    public SeedRanges(IEnumerable<long> seedEnumerable)
    {
        var enumerable = seedEnumerable as long[] ?? seedEnumerable.ToArray();
        var evenIndexNumbers = enumerable.Where((x, i) => i % 2 == 0);
        var oddIndexNumbers = enumerable.Where((x, i) => i % 2 != 0);
        Ranges = evenIndexNumbers.Zip(oddIndexNumbers, (start, length) =>new SeedRange(start, start + length) );
    }

    public IEnumerable<SeedRange> Ranges { get; }

    public Func<long,bool> IsInRange => seed=>Ranges.Any(r=>r.IsInRange(seed));
  
}