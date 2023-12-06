namespace AdventOfCode.Day6;

public record RaceData(long Time, long Distance)
{
    public IEnumerable<RaceData> GetWays()
    {
        for (var way = 1; way < Time; way++)
        {
            var speed = way;
            var remainingTime = Time - way;
            var distance = speed * remainingTime;
            if(distance>Distance)
               yield return this with { Distance = distance };
        }
    }
}