using AdventOfCode.Day9;
using FluentAssertions;

namespace UnitTests;

public class Day9Tests
{
    [Fact]
    public void Test1()
    {
        string data = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";

        var lines = data.Split(Environment.NewLine,StringSplitOptions.RemoveEmptyEntries);
        var items = lines.Select(l => l.ToReport()).ToArray();
        items[0].Sequence[0].Should().Be(0);
        items[0].Sequence[1].Should().Be(3);

        items[0].Sequence.Next().Should().Be(18);
        items[1].Sequence.Next().Should().Be(28);
        items[2].Sequence.Next().Should().Be(68);

        items.Sum(i => i.NextValue).Should().Be(114);
       items.Sum(i => i.PreviousValue).Should().Be(2);

    }
    
    [Fact]
    public void Test2()
    {

        "1 3 6 10 15 21".ToReport().PreviousValue.Should().Be(0);


    }
}