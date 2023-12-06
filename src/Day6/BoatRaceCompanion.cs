using System.Runtime.InteropServices.JavaScript;

namespace AdventOfCode.Day6;

public static class BoatRaceCompanion
{
    public static IEnumerable<RaceData> GetRaceData(this string data)
    {
        var sr = new StringReader(data);
        var timesString = sr.ReadLine()!.Split(":",StringSplitOptions.RemoveEmptyEntries)[1].Split(" ",StringSplitOptions.RemoveEmptyEntries);
        var distanceString = sr.ReadLine()!.Split(":",StringSplitOptions.RemoveEmptyEntries)[1].Split(" ",StringSplitOptions.RemoveEmptyEntries);

        return timesString.Zip(distanceString, (time,distance) => new RaceData(long.Parse(time),long.Parse(distance)));
    }
    
    public static RaceData GetRaceData2(this string data)
    {
        var strings = data.Split('\n',StringSplitOptions.RemoveEmptyEntries);
        var timeChars = new string(strings[0].Where(char.IsNumber).ToArray());
        var distanceChars = new string(strings[1].Where(char.IsNumber).ToArray());
        
        return new RaceData(long.Parse(timeChars), long.Parse(distanceChars));
    }
}