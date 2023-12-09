using System.Text.RegularExpressions;
using AdventOfCode.Day_8;
using FluentAssertions;

namespace UnitTests;



public class Day8Tests
{

    [Fact]
    public void Test()
    {
        var data =  @"RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)";
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var overAllMap = lines.ToMaps();

        overAllMap.LeftRights.Should().Be("RL");

        overAllMap.MapItems.Count().Should().Be(7);
        overAllMap.MapItems[0].Start.Should().Be("AAA");
        overAllMap.Steps().Should().Be(2L);
    }
    
    [Fact]
    public void Test2()
    {
        var data =  @"LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)";
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var overAllMap = lines.ToMaps();

        overAllMap.LeftRights.Should().Be("LLR");

        overAllMap.MapItems.Count().Should().Be(3);
        overAllMap.MapItems[0].Start.Should().Be("AAA");
        overAllMap.Steps().Should().Be(6L);
    }
    
    [Fact]
    public void Test3()
    {
        var data =  @"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)";
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var overAllMap = lines.ToMaps();
        
        overAllMap.GhostSteps().Should().Be(6L);
    }
}

