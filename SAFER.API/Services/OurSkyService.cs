using System.Net.Http;
using System.Threading.Tasks;

namespace SAFER.API.Services;

public class OurSkyService
{
     private readonly HttpClient _httpClient;

    public OurSkyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetSampleObservationAsync()
    {
        // 🔧 Replace this with a real OurSky endpoint when ready
        var response = await _httpClient.GetAsync("https://httpbin.org/json");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
}