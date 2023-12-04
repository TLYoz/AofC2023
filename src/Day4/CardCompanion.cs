namespace AdventOfCode.Day4;

public static class CardCompanion
{
    private static Card Parse(this string line)
    {
        var cardSplit = line.Split(":");
        var drawSplit = cardSplit[1].Split("|");

        return new Card(int.Parse(cardSplit[0].Remove(0, 5)), 
            drawSplit[0].Split(" ",StringSplitOptions.RemoveEmptyEntries), 
            drawSplit[1].Split(" ",StringSplitOptions.RemoveEmptyEntries));
    }
    
    public static List<Card> ParseAll(this IEnumerable<string> lines) => lines.Select(l=>l.Parse()).ToList();
    
}