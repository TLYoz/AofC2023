namespace AdventOfCode.Day2;

public static class BallGameCompanion
{
    public static int SumPossibleGamesForBag(this IEnumerable<Game> games, Bag bag) => 
        games.Where(bag.IsViable).Sum(g=>g.GameNumber);
    
    public static int SumOfMinPossibleProducts(this IEnumerable<Game> games) => games.Sum(g=>g.Power());
}