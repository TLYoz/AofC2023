namespace AdventOfCode.Day3;

public static class EngineCompanion
{
    private static bool IsSymbol(this char c) => !char.IsNumber(c) && c != '.';
    
    public static List<Coordinate> SymbolLocations(this string[] lines) => lines.Locations(c => c.IsSymbol());

    private static List<Coordinate> Locations(this string[] lines, Func<char,bool> func)
    {
        var locations = new List<Coordinate>();

        var y = 0;
        foreach (var line in lines)
        {
            var x = 0;
            foreach (var c in line.ToCharArray())
            {
                if(func(c))
                    locations.Add(new Coordinate(x,y));
                x++;
            }
            y++;
        }

        return locations;
    }

    public static int SumOfGearRatios(this List<PartNumber> partNumbers,IEnumerable<Coordinate> gearLocations) =>
        gearLocations.Sum(gl =>
        {
            var enumerable = partNumbers.Where(pn => pn.IsAdjacent( gl ));
            return enumerable.Count() == 2 ? enumerable.First().Number * enumerable.Last().Number : 0;
        });

    public static int SumOfPartNumbers(this List<PartNumber> partNumbers,List<Coordinate> symbolLocations) => 
        partNumbers.Where(pn=>pn.IsReal(symbolLocations)).Select(pn => pn.Number).Sum();

    public static List<Coordinate> GearLocations(this string[] lines) => lines.Locations(c => c == '*');
    
    public static List<PartNumber> PartNumbers(this string[] lines)
    {
        List<PartNumber> partNumbers = new List<PartNumber>();

        var y = 0;
        foreach (var line in lines)
        {
            // state machine yuk!
            int x = 0;
            PartNumber? pn = null;
            foreach (var c in line.ToCharArray()) 
            {
                if (char.IsNumber(c))
                {
                    if (pn == null)
                        pn = new PartNumber(new Coordinate(x, y), new List<char> { c }); // finding the start of a new number
                    else
                        pn.Chars.Add(c); // continuation of a number
                }
                else
                {
                    if(pn!=null)
                        partNumbers.Add(pn); // number is complete add to collection
                    pn = null;
                }
                x++;
                // if you are on a number at the end of the line add to collection
                if(x==line.Length && pn!=null)
                    partNumbers.Add(pn); 
            }
            y++;
        }

        return partNumbers;
    }
}