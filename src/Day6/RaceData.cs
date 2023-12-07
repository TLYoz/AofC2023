namespace AdventOfCode.Day6;

public record RaceData(long Time, long Distance)
{
    public int GetWays()
    {
        var i = 0;
        for (var way = 1; way < Time; way++)
        {
            var speed = way;
            var remainingTime = Time - way;
            var distance = speed * remainingTime;
            if (distance > Distance)
                i++;
        }

        return i;
    }
}