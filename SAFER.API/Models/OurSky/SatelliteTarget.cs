using System.Text.Json.Serialization;

namespace SAFER.API.Models.OurSky
{
    public class SatelliteTarget
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("tleName")]
        public required string TleName { get; set; }

        [JsonPropertyName("noradId")]
        public required string NoradId { get; set; }

        [JsonPropertyName("orbitType")]
        public required string OrbitType { get; set; }

        [JsonPropertyName("inclination")]
        public required double Inclination { get; set; }

        [JsonPropertyName("trackingStatus")]
        public required string TrackingStatus { get; set; }
    }
}