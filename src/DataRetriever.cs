using System.Net;

namespace AdventOfCode;

public  class DataRetriever
{
    private readonly string _session;

    private static readonly Func<int, string> uriTemplate = day => $"https://adventofcode.com/2023/day/{day}/input";

    public DataRetriever(string session) => _session = session;

    public  async Task<string[]> GetDataLines(int day)
    {
        var data = await GetData(day);
        return data.Split("\n", StringSplitOptions.RemoveEmptyEntries);
    }
    
    public  async Task<string> GetData(int day)
    {
        var baseAddress = new Uri(uriTemplate(day));
        var cookieContainer = new CookieContainer();
        using var handler = new HttpClientHandler { CookieContainer = cookieContainer };
        using var client = new HttpClient(handler) { BaseAddress = baseAddress };
        cookieContainer.Add(baseAddress, new Cookie("session", _session));
        return await client.GetStringAsync(baseAddress);
    }
}