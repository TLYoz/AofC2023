// See https://aka.ms/new-console-template for more information

using AdventOfCode;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Day4;
using AdventOfCode.Day5;
using AdventOfCode.Day6;
using AdventOfCode.Day7;

// replace with your unique session id from the AoC cookie
var sessionId = "53616c7465645f5f384bfbe287e9d2ab6b964c8dbf338344dde6c35f7a19c5fcecc8b56b720cac2f3fa50966289dac768857ec4ff13af1aa380fbfdb8619361c";

var dataRetriever = new DataRetriever(sessionId);

// day 1
var data1 = await dataRetriever.GetDataLines(day: 1);

// part 1
Console.WriteLine($"Day 1: Part 1 Sum of All numbers {data1.SumOfAllNumbers()}");
// part 2
Console.WriteLine($"Day 1: Part 2 Sum of All numbers including words {data1.SumOfAllNumbers(includeWords: true)}");

// day 2

var data2 = await dataRetriever.GetDataLines(day: 2);

var games = data2.Select(Game.Parse).ToArray();

// part 1
Console.WriteLine($"Day 2: Part 1: Sum of possible game Id {games.SumPossibleGamesForBag(new Bag(12,13,14))}");
// part 2
Console.WriteLine($"Day 2: Part 2: Product of minimum viable bags {games.SumOfMinPossibleProducts()}");

// day 3 

var data3 = await dataRetriever.GetDataLines(day: 3);

var symbol_locations = data3.SymbolLocations();

var partNumbers = data3.PartNumbers();

Console.WriteLine($"Day 3: Part 1: Sum of part numbers {partNumbers.SumOfPartNumbers(symbol_locations)}");

// part 2

var gear_locations = data3.GearLocations();

Console.WriteLine($"Day 3: Part 2: Sum of gear ratios {partNumbers.SumOfGearRatios(gear_locations)}");

// Day 4

// part 1

var data4 = await dataRetriever.GetDataLines(day: 4);

var cards = data4.ParseAll();

Console.WriteLine($"Day 4: Part 1: Sum of Card Points {cards.Sum(c => c.Value)}");

// part 2

Console.WriteLine($"Day 4: Part 2: Sum of Cards {cards.Aggregate(0, (acc, card) => card.CountRecursive(cards, ref acc))}"); // ref needed pass-by-value not ok 

// Day 5

var data5 = await dataRetriever.GetData(day: 5);

var almanac = data5.Parse();

Console.WriteLine($"Day 5: Part 1: Minimum Distance {almanac.Seeds.Min(s=>almanac.ClosestLocation(s))}");
//Day 5: Part 1: Minimum Distance 214922730

Console.WriteLine($"Day 5: Part 2: Minimum Distance from Seed Ranges {almanac.Inflexions().Min(s=>almanac.ClosestLocation(s))}"); 
//Day 5: Part 2: Minimum Distance from Seed Ranges 148041808


// Day 6 

var data6 = await dataRetriever.GetData(6);

Console.WriteLine($"Day 6: Part 1: Multiple of all races {data6.GetRaceData().Aggregate(1,(count, data) => count *  data.GetWays())}");
//Your puzzle answer was 2344708.
Console.WriteLine($"Day 6: Part 2: Multiple of all races different Interpretation {data6.GetRaceData2().GetWays()}");
// Your puzzle answer was 30125202.


// Day 7
var data7 = await dataRetriever.GetDataLines(7);

var hands = data7.ToHands();

Console.WriteLine($"Day 7: Part 1: Hands {hands.RankExcludingJokers().Sum()}");
//Day 7: Part 1: Hands 250474325

Console.WriteLine($"Day 7: Part 2: Hands with wild cards {hands.RankIncludingJokers().Sum()}");
//Day 7: Part 2: Hands with wild cards 248909434
