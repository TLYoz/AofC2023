using System.Text.RegularExpressions;

namespace AdventOfCode.Day_8;

public static class MapCompanion
{
    private static readonly Regex regex = new("^([0-9A-Z]{3}) = \\(([0-9A-Z]{3}), ([0-9A-Z]{3})\\)");
    public static Maps ToMaps(this string[] lines)
    {
        var leftRights = lines.First().Trim();
        var mapItems = lines.Skip(1).Select(line => line.ToMap()).ToList();
        return new(leftRights, mapItems);
    }

    private static Map ToMap(this string line)
    {
        var m = regex.Matches(line);

        string Group(int i) => m[0].Groups[i].Value;

        return new Map(Group(1), Group(2), Group(3));
    }
}