namespace AdventOfCode.Day5;

public class Almanac
{
    public long[] Seeds { get; }

    private readonly Map _seedToSoil,
        _soilToFertilizer,
        _fertilizerToWater,
        _waterToLight,
        _lightToTemperature,
        _temperatureToHumidity,
        _humidityToLocation;

    private IEnumerable<Map> Maps => new[]
    {
        _seedToSoil, _soilToFertilizer, _fertilizerToWater, _waterToLight, _lightToTemperature, _temperatureToHumidity,
        _humidityToLocation
    };

    internal Almanac(long[] seeds,
        Map seedToSoil,
        Map soilToFertilizer,
        Map fertilizerToWater,
        Map waterToLight,
        Map lightToTemperature,
        Map temperatureToHumidity,
        Map humidityToLocation)
    {
        Seeds = seeds;
        _seedToSoil = seedToSoil;
        _soilToFertilizer = soilToFertilizer;
        _fertilizerToWater = fertilizerToWater;
        _waterToLight = waterToLight;
        _lightToTemperature = lightToTemperature;
        _temperatureToHumidity = temperatureToHumidity;
        _humidityToLocation = humidityToLocation;
    }

    public long ClosestLocation(long seed) => Maps.Aggregate(seed, (source, map) => map.SourceToDestination(source));

    // because the target function for discovery of minimum is a saw tooth, stochastic methods are no use
    // but we can calculate the points of inflexion by reverse mapping the maps coordinates 
    // we filter these inflexions by seed id's that are in valid ranges
    public IEnumerable<long> Inflexions()
    {
        var mapReversed = Maps.Reverse().ToArray();
        return mapReversed.Aggregate((List: Enumerable.Empty<long>(), ReverseMap: mapReversed), MapContribution())
            .List
            .Where(IsInSeedRanges).ToArray();
    }

    private static Func<(IEnumerable<long> List, Map[] ReverseMap), Map, (IEnumerable<long> List, Map[] ReverseMap)> MapContribution() =>
        (acc, currentMap) =>
            (acc.List.Concat(InflexionsForMap(currentMap, acc)), acc.ReverseMap.Skip(1).ToArray());

    private static IEnumerable<long> InflexionsForMap(Map currentMap, (IEnumerable<long>, Map[] reverse) acc) =>
        currentMap.Entries.Select(me => me.SourceStart + me.Delta).Select(source =>
            acc.Item2.Aggregate(source, (destination, map) => map.DestinationToSource(destination)));

    private bool IsInSeedRanges(long seed)
    {
        for (var i = 0; i < Seeds.Length - 1; i += 2)
        {
            var start = Seeds[i];
            if (seed >= start && seed < start + Seeds[i + 1])
                return true;
        }
        return false;
    }
}