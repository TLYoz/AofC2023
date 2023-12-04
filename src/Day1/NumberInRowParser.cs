namespace AdventOfCode.Day1;

public static class NumberInRowParser
{
    private static readonly List<string> numbers = new()
        { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    public static int SumOfAllNumbers(this IEnumerable<string> lines, bool includeWords = false) => 
        lines.Aggregate(0, (acc, b) => acc + b.FirstNumberInString(includeWords) * 10 + b.LastNumberInString(includeWords));

    private static int FirstNumberInString(this string str, bool includeWords = true)
    {
        for (var i = 0; i < str.Length; i++) // look forwards 
            if (includeWords?TryGetNumber(str[i..], out var value):TryGetDigit(str[i..], out  value))
                return value!.Value;

        throw new Exception($"no first number found - {str}");
    }

    private static int LastNumberInString(this string str, bool includeWords = true)
    {
        for (var i = str.Length - 1; i >= 0; i--) // look backwards
            if (includeWords?TryGetNumber(str[i..], out var value):TryGetDigit(str[i..], out  value))
                return value!.Value;

        throw new Exception($"no last number found - {str}");
    }

    // get by digit or word
    private static bool TryGetNumber(string remaining, out int? value)
    {
        value = null;
        return TryGetDigit(remaining, out value) || TryGetWord(remaining, out value);
    }

    private static bool TryGetDigit(string remaining, out int? value)
    {
        value = null;
        if (char.IsNumber(remaining.First()))
        {
            value = int.Parse(remaining.First().ToString());
            return true;
        }

        return false;
    }

    private static bool TryGetWord(string remaining, out int? value)
    {
        value = null;
        var firstOrDefault = numbers.FirstOrDefault(remaining.StartsWith);
        if (firstOrDefault != null)
        {
            value = numbers.IndexOf(firstOrDefault) + 1;
            return true;
        }

        return false;
    }
}