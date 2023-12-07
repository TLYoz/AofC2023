namespace AdventOfCode.Day7;

public record Hand(string Cards, long Bid)
{
    public CardType Type =>
        IsXofAKind(5) ? CardType.FiveOfAKind :
        IsXofAKind(4) ? CardType.FourOfAKind :
        IsFullHouse() ? CardType.FullHouse :
        IsXofAKind(3) ? CardType.ThreeOfAKind :
        IsTwoPairs() ? CardType.TwoPair :
        IsXofAKind(2) ? CardType.OnePair :
        CardType.HighCard;
    
    public CardType TypeIncludingJokers =>
        IsXofAKindJ(5) ? CardType.FiveOfAKind :
        IsXofAKindJ(4) ? CardType.FourOfAKind :
        IsFullHouseJ() ? CardType.FullHouse :
        IsXofAKindJ(3) ? CardType.ThreeOfAKind :
        IsTwoPairsJ() ? CardType.TwoPair :
        IsXofAKindJ(2) ? CardType.OnePair :
        CardType.HighCard;

    private bool IsXofAKind(int size,IEnumerable<char>? cards = null) => (cards ?? Cards).GroupBy(c=>c).Any(g=>g.Count()==size);
    private bool IsFullHouse() => IsXofAKind(2) && IsXofAKind(3);
    private bool IsTwoPairs(IEnumerable<char>? cards = null) => (cards ?? Cards).GroupBy(c => c).Count(g => g.Count() == 2) == 2;
    private bool IsXofAKindJ(int size) => IsXofAKind(size) || (MaxGroupSizeIgnoreJ+WildCardCount >= size);
    private bool IsFullHouseJ() => IsFullHouse() || (WildCardCount == 1 && IsTwoPairs(NonWildCards));
    private bool IsTwoPairsJ() => IsTwoPairs();
    
    private int WildCardCount => Cards.Count(c => c.Equals('J'));
    private int MaxGroupSizeIgnoreJ => NonWildCards.GroupBy(c=>c).Max(g=>g.Count());
    private IEnumerable<char> NonWildCards => Cards.Where(c=>!c.Equals('J'));
}