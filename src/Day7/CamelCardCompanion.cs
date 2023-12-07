namespace AdventOfCode.Day7;

public static class CamelCardCompanion
{
    public static Hand ParseCard(this string line)
    {
        var split = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        return new Hand(split[0], long.Parse(split[1].ToArray()));
    }
    
    public static List<Hand> ToHands(this IEnumerable<string> lines) => lines.Select(ParseCard).ToList();

    public static List<Hand> RankExcludingJokers(this List<Hand> hands) => hands.OrderBy(h => h.Type).ThenBy(h=>h.Cards,new CardComparer()).ToList();

    public static List<Hand> RankIncludingJokers(this List<Hand> hands) => hands.OrderBy(h => h.TypeIncludingJokers).ThenBy(h=>h.Cards,new CardComparer(includeWildCards: true)).ToList();
    
    public static long Sum(this List<Hand> hands)
    {
        var i = 1;
        return hands.Aggregate(0L,(acc,hand)=> acc + hand.Bid * i++);
    }
}