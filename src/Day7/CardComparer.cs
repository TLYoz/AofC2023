namespace AdventOfCode.Day7;

public class CardComparer : IComparer<string>
{
    private readonly List<char> _cardOrder;

    public CardComparer(bool includeWildCards = false)
    {
        _cardOrder = includeWildCards
            ? new() { 'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' }
            : new() { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
    }

    public int Compare(string x, string y)
    {
        if (x == null) throw new ArgumentNullException(nameof(x));
        var xs = x.ToArray();
        var ys = y.ToArray();
        for (var i = 0; i < x.Length; i++)
        {
            if (_cardOrder.IndexOf(xs[i]) > _cardOrder.IndexOf(ys[i]))
                return 1;
            if (_cardOrder.IndexOf(xs[i]) < _cardOrder.IndexOf(ys[i]))
                return -1;
        }

        return 0;
    }
}

