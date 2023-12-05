namespace AdventOfCode.Day5;

public static class AlmanacCompanion
{
    public static Almanac Parse(this string data)
    {
        StringReader sr = new StringReader(data);
        var seeds = sr.ReadLine()!.Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        sr.ReadLine();
        var seedToSoil =sr.ReadLine()!.Contains("seed-to-soil") ? Build(sr) : null;
        var soilToFertilizer =sr.ReadLine()!.Contains("soil-to-fertilizer") ? Build(sr) : null;
        var fertilizerToWater =sr.ReadLine()!.Contains("fertilizer-to-water") ? Build(sr) : null;
        var waterToLight =sr.ReadLine()!.Contains("water-to-light") ? Build(sr) : null;
        var lightToTemperature =sr.ReadLine()!.Contains("light-to-temperature") ? Build(sr) : null;
        var temperatureToHumidity =sr.ReadLine()!.Contains("temperature-to-humidity") ? Build(sr) : null;
        var humidityToLocation =sr.ReadLine()!.Contains("humidity-to-location") ? Build(sr) : null;

        return new Almanac(seeds, seedToSoil!,soilToFertilizer!,fertilizerToWater!,waterToLight!,lightToTemperature!,temperatureToHumidity!,humidityToLocation!);
    }
    
    private static Map Build(TextReader sr) 
    {
        var map = new Map();
        var line = sr.ReadLine();
        while ( !string.IsNullOrWhiteSpace(line))
        {
            map.Entries.Add(MapEntry.Parse(line));
            line = sr.ReadLine();
        }
        return map;
    }
}