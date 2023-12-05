using System.Net;

namespace AdventOfCode;

public  class DataRetriever
{
    private readonly string _session;

    public DataRetriever(string session) => _session = session;

    public  async Task<string[]> GetDataLines(string uri)
    {
        var data = await GetData(uri);
        return data.Split("\n", StringSplitOptions.RemoveEmptyEntries);
    }
    
    public  async Task<string> GetData(string uri)
    {
        var baseAddress = new Uri(uri);
        var cookieContainer = new CookieContainer();
        using var handler = new HttpClientHandler { CookieContainer = cookieContainer };
        using var client = new HttpClient(handler) { BaseAddress = baseAddress };
        cookieContainer.Add(baseAddress, new Cookie("session", _session));
        return await client.GetStringAsync(baseAddress);
    }
    
    
}