namespace AdventOfCode.Day3;

public record PartNumber(Coordinate Coordinate, List<char> Chars)
{
    public bool IsReal(List<Coordinate> symbol_locations) => Is(symbol_locations.Contains);

    private bool Is(Func<Coordinate, bool> func)
    {
        for (var x = Coordinate.X - 1; x <= Coordinate.X +Chars.Count; x++)
        for (var y = Coordinate.Y - 1; y <= Coordinate.Y + 1; y++)
            if (func(new Coordinate(x, y)))
                return true;
        return false;
    }

    public bool IsAdjacent(Coordinate coordinate) => Is(c => coordinate == c);

    public int Number => int.Parse(Chars.ToArray());
};