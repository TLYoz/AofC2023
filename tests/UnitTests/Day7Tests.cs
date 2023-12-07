using AdventOfCode.Day7;
using FluentAssertions;

namespace UnitTests;

public class Day7Tests
{
    private readonly List<Hand> _hands;

    private const string data = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";

    public Day7Tests() => _hands = data.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToHands();

    [Fact]
    public void CardTypeResolution()
    {
        _hands[1].Type.Should().Be(CardType.ThreeOfAKind);
        _hands[0].Type.Should().Be(CardType.OnePair);
     
        _hands[4].Type.Should().Be(CardType.ThreeOfAKind);

        _hands[3].Type.Should().Be(CardType.TwoPair);
        _hands[2].Type.Should().Be(CardType.TwoPair);

        "KKKKK 123".ParseCard().Type.Should().Be(CardType.FiveOfAKind);
        "KKKKQ 123".ParseCard().Type.Should().Be(CardType.FourOfAKind);
        "KK234 123".ParseCard().Type.Should().Be(CardType.OnePair);
        "23456 123".ParseCard().Type.Should().Be(CardType.HighCard);
    }

    [Fact]
    public void HandRank()
    {
        _hands.RankExcludingJokers().Select(h => h.Cards).Should().BeEquivalentTo("32T3K", "KTJJT", "KK677", "T55J5", "QQQJA" );
    }
    
    [Fact]
    public void CardTypeResolutionJ()
    {
        _hands[0].TypeIncludingJokers.Should().Be(CardType.OnePair);
        _hands[1].TypeIncludingJokers.Should().Be(CardType.FourOfAKind);
        _hands[2].TypeIncludingJokers.Should().Be(CardType.TwoPair);
        _hands[3].TypeIncludingJokers.Should().Be(CardType.FourOfAKind);
        _hands[4].TypeIncludingJokers.Should().Be(CardType.FourOfAKind);

        new Hand("JJJJJ",0).TypeIncludingJokers.Should().Be(CardType.FiveOfAKind);
        new Hand("JJJJA",0).TypeIncludingJokers.Should().Be(CardType.FiveOfAKind);
        new Hand("JJJAA",0).TypeIncludingJokers.Should().Be(CardType.FiveOfAKind);
        new Hand("JJAAA",0).TypeIncludingJokers.Should().Be(CardType.FiveOfAKind);
        new Hand("JAAAA",0).TypeIncludingJokers.Should().Be(CardType.FiveOfAKind);
        
        new Hand("JJJQA",0).TypeIncludingJokers.Should().Be(CardType.FourOfAKind);
        new Hand("JJJQA",0).TypeIncludingJokers.Should().Be(CardType.FourOfAKind);
        new Hand("JJAQA",0).TypeIncludingJokers.Should().Be(CardType.FourOfAKind);
        new Hand("JAAQA",0).TypeIncludingJokers.Should().Be(CardType.FourOfAKind);
        
        new Hand("JJJQQ",0).TypeIncludingJokers.Should().Be(CardType.FiveOfAKind);
        new Hand("JTTQQ",0).TypeIncludingJokers.Should().Be(CardType.FullHouse);
        new Hand("JJTQQ",0).TypeIncludingJokers.Should().Be(CardType.FourOfAKind);

        new Hand("2345J",0).TypeIncludingJokers.Should().Be(CardType.OnePair);
    }
    
    
    [Fact]
    public void HandRankJ()
    {
        _hands.RankIncludingJokers().Select(h => h.Cards).Should().BeEquivalentTo("32T3K", "KTJJT", "KK677", "T55J5", "QQQJA" );
    }
    
    [Fact]
    public void Product()
    {
        var i = 1;
        var aggregate = _hands.RankExcludingJokers().Aggregate(0L,(acc,hand)=>
        {
            Console.WriteLine($"{hand.Bid} * {i}");
            return acc + hand.Bid * i++;
        });
        aggregate.Should().Be(6440);
    }
    
    [Fact]
    public void ProductJ()
    {
        var i = 1;
        var aggregate = _hands.RankIncludingJokers().Aggregate(0L,(acc,hand)=>
        {
            Console.WriteLine($"{hand.Bid} * {i}");
            return acc + hand.Bid * i++;
        });
        aggregate.Should().Be(5905);
    }
}