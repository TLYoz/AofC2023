namespace AdventOfCode.Day5;

public record SeedRange(long Start, long End)
{
    public bool IsInRange(long seed) => seed >= Start && seed < End;
}