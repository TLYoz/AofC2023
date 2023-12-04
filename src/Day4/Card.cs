namespace AdventOfCode.Day4;

public class Card
{
    private readonly string[] _intersect;

    public Card(int Number, IEnumerable<string> WinningNumbers, IEnumerable<string> DrawNumbers)
    {
        this.Number = Number;
        _intersect = WinningNumbers.Intersect(DrawNumbers).ToArray();
    }

    private int Number { get; }
    public int Value => _intersect.Aggregate(0,(acc,_) => acc == 0 ? 1 : acc * 2 );

    public int CountRecursive(IEnumerable<Card> allCards, ref int acc)
    {
        acc += 1;
        foreach (var c in allCards.Skip(Number).Take(_intersect.Length))
            c.CountRecursive(allCards, ref acc);
        return acc;
    }
}