namespace AdventOfCode.Day5;

/// <summary>
/// This class is just to hold the Maps and initial Seed and provide support for sorting ideal seed locations 
/// </summary>
public class Almanac
{
    private readonly Map _seedToSoil,
        _soilToFertilizer,
        _fertilizerToWater,
        _waterToLight,
        _lightToTemperature,
        _temperatureToHumidity,
        _humidityToLocation;

    private readonly SeedRanges _seedRanges;

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
        _seedRanges = new SeedRanges(Seeds);
        _seedToSoil = seedToSoil;
        _soilToFertilizer = soilToFertilizer;
        _fertilizerToWater = fertilizerToWater;
        _waterToLight = waterToLight;
        _lightToTemperature = lightToTemperature;
        _temperatureToHumidity = temperatureToHumidity;
        _humidityToLocation = humidityToLocation;
    }
    
    public long[] Seeds { get; }

    // this folds over all Maps from Seed -> Location
    public long ClosestLocation(long seed) => Maps.Aggregate(seed, (source, map) => map.SourceToDestination(source));

    // because the target function for discovery of minimum is a saw tooth, stochastic methods are no use
    // but we can calculate the points of inflexion by reverse mapping the maps coordinates 
    // we filter these inflexions by seed id's that are in valid ranges
    public IEnumerable<long> Inflexions()
    {
        var mapReversed = Maps.Reverse().ToArray();
        var initialSeedArray = _seedRanges.Ranges.Select(r=>r.Start);
        var inflexionAccumulator = new InflexionAccumulator(mapReversed.Skip(1),initialSeedArray);

        return mapReversed
            .Aggregate(inflexionAccumulator, (acc, map) => acc.Next(map))
            .AccumulatedInflexions
            .Where(_seedRanges.IsInRange);
    }
}