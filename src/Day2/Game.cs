namespace AdventOfCode.Day2;

public class Game
{
    public int GameNumber { get; private init; }
    public IEnumerable<Draw> Draws { get; private init; } = null!;

    public int Power() => Draws.Max(d => d.Blue) * Draws.Max(d => d.Green) * Draws.Max(d => d.Red);

    public static Game Parse(string gameString)
    {
        var (gameNumber, drawStrings)  = Split(gameString);
        return new Game { GameNumber = gameNumber, Draws = drawStrings.Select(Draw.Parse) };
    }
    
    private static (int gameNumber, string[] drawStrings) Split(string gameString)
    {
        var split = gameString.Split(":");
        return (int.Parse(split[0].AsSpan(5)), split[1].Split(";"));
    }
}