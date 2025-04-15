using System.Text;
using System.Text.Json;
using SAFER.API.Models.OurSky;

namespace SAFER.API.Services;

public class OurSkyService
{
     private readonly HttpClient _httpClient;

    public OurSkyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // public async Task<string> GetSampleObservationAsync()
    // {
    //     // 🔧 Replace this with a real OurSky endpoint when ready
    //     var response = await _httpClient.GetAsync("https://api.prod.oursky.ai");
        

    //     response.EnsureSuccessStatusCode();

    //     var content = await response.Content.ReadAsStringAsync();
    //     return content;
    // }

    public async Task<IEnumerable<SatelliteTarget>> GetSatelliteTargetsAsync()
    {
        var response = await _httpClient.GetAsync("v1/satellite-targets");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var wrapper = JsonSerializer.Deserialize<OurSkyTargetResponse>(content);
        return wrapper?.Targets ?? new List<SatelliteTarget>();
        //return await response.Content.ReadAsStringAsync();
    }
public async Task<bool> CreateOrgTargetAsync(CreateOrgTargetRequest request)
{
object payload;

if (request.RevisitRateMinutes.HasValue)
{
    payload = new
    {
        satelliteTargetId = request.SatelliteTargetId,
        revisitRateMinutes = request.RevisitRateMinutes.Value
    };
}
else
{
    payload = new
    {
        satelliteTargetId = request.SatelliteTargetId
    };
}

    var json = JsonSerializer.Serialize(payload);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    var httpRequest = new HttpRequestMessage(HttpMethod.Post, "organization-target")
    {
        Content = content
    };

    var response = await _httpClient.SendAsync(httpRequest);

    if (!response.IsSuccessStatusCode)
    {
        var error = await response.Content.ReadAsStringAsync();
        //TODO logging
        // _logger.LogError("Failed to create organization target: {Error}", error);
        return false;
    }

    return true;
}
}