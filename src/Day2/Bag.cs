namespace AdventOfCode.Day2;

public record Bag(int Red, int Green, int Blue) 
{
    public  Func<Game,bool> IsViable => game => game.Draws.All(draw => draw.IsPossible(this));
}