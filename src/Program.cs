﻿// See https://aka.ms/new-console-template for more information

using AdventOfCode;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Day4;
using AdventOfCode.Day5;

var dataRetriever = new DataRetriever("53616c7465645f5f384bfbe287e9d2ab6b964c8dbf338344dde6c35f7a19c5fcecc8b56b720cac2f3fa50966289dac768857ec4ff13af1aa380fbfdb8619361c");

// day 1
var data1 = await dataRetriever.GetDataLines("https://adventofcode.com/2023/day/1/input");

// part 1
Console.WriteLine($"Day 1: Part 1 Sum of All numbers {data1.SumOfAllNumbers()}");
// part 2
Console.WriteLine($"Day 1: Part 2 Sum of All numbers including words {data1.SumOfAllNumbers(includeWords: true)}");

// day 2

var data2 = await dataRetriever.GetDataLines("https://adventofcode.com/2023/day/2/input");

var games = data2.Select(Game.Parse).ToArray();

// part 1
Console.WriteLine($"Day 2: Part 1: Sum of possible game Id {games.SumPossibleGamesForBag(new Bag(12,13,14))}");
// part 2
Console.WriteLine($"Day 2: Part 2: Product of minimum viable bags {games.SumOfMinPossibleProducts()}");

// day 3 

var data3 = await dataRetriever.GetDataLines("https://adventofcode.com/2023/day/3/input");

var symbol_locations = data3.SymbolLocations();

var partNumbers = data3.PartNumbers();

Console.WriteLine($"Day 3: Part 1: Sum of part numbers {partNumbers.SumOfPartNumbers(symbol_locations)}");

// part 2

var gear_locations = data3.GearLocations();

Console.WriteLine($"Day 3: Part 2: Sum of gear ratios {partNumbers.SumOfGearRatios(gear_locations)}");

// Day 4

// part 1

var data4 = await dataRetriever.GetDataLines("https://adventofcode.com/2023/day/4/input");

var cards = data4.ParseAll();

Console.WriteLine($"Day 4: Part 1: Sum of Card Points {cards.Sum(c => c.Value)}");

// part 2

Console.WriteLine($"Day 4: Part 2: Sum of Cards {cards.Aggregate(0, (acc, card) => card.CountRecursive(cards, ref acc))}"); // ref needed pass-by-value not ok 

// Day 5

var data5 = await dataRetriever.GetData("https://adventofcode.com/2023/day/5/input");

var almanac = data5.Parse();

Console.WriteLine($"Day 5: Part 1: Minimum Distance {almanac.Seeds.Min(s=>almanac.ClosestLocation(s))}");
//Day 5: Part 1: Minimum Distance 214922730

Console.WriteLine($"Day 5: Part 2: Minimum Distance from Seed Ranges {almanac.Inflexions().Min(s=>almanac.ClosestLocation(s))}"); 
//Day 5: Part 2: Minimum Distance from Seed Ranges 148041808

