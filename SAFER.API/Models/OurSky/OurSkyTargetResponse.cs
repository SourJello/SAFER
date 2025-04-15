using System.Text.Json.Serialization;

namespace SAFER.API.Models.OurSky
{
    public class OurSkyTargetResponse
    {
        [JsonPropertyName("targets")]
        public List<SatelliteTarget> Targets { get; set; } = new();
    }
}