using System.Net;

namespace AdventOfCode;

public  class DataRetriever
{
    private readonly string _session;

    public DataRetriever(string session) => _session = session;

    public  async Task<string[]> GetData(string uri)
    {
        var baseAddress = new Uri(uri);
        var cookieContainer = new CookieContainer();
        using var handler = new HttpClientHandler { CookieContainer = cookieContainer };
        using var client = new HttpClient(handler) { BaseAddress = baseAddress };
        cookieContainer.Add(baseAddress, new Cookie("session", _session));
        var data = await client.GetStringAsync(baseAddress);
        return data.Split("\n", StringSplitOptions.RemoveEmptyEntries);
    }
}