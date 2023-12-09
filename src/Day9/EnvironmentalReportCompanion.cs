namespace AdventOfCode.Day9;

public static class EnvironmentalReportCompanion
{
    public static Report ToReport(this string line)
    {
        var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return new (split.Select(long.Parse).ToList());
    }

    public static long Next(this List<long> Sequence)
    {
        var lstOfLasts = new List<long> {Sequence.Last()};
        var nextSequence = Sequence;
        while (nextSequence.GroupBy(i=>i).Count()>1)
        {
            nextSequence = NextSequence(Sequence);
            lstOfLasts.Add(nextSequence.Last());
            Sequence = nextSequence;
        }

        return lstOfLasts.Sum();
    }
    
    public static long Previous(this List<long> Sequence)
    {
        var listOfSequences = new List<List<long>> { Sequence };
        var nextSequence = Sequence;

        while (nextSequence.GroupBy(i=>i).Count()>1)
        {
            nextSequence = NextSequence(Sequence);
            listOfSequences.Add(nextSequence);
            Sequence = nextSequence;
        }

        for (var i = listOfSequences.Count-1; i > 0; i--)
            listOfSequences[i - 1].Insert(0, listOfSequences[i - 1].First() - listOfSequences[i].First());
        
        return listOfSequences.First().First();
    }

    private static List<long> NextSequence(IReadOnlyCollection<long> Sequence) => 
        Sequence.Zip(Sequence.Skip(1)).Select(zip => zip.Second - zip.First).ToList();
}

