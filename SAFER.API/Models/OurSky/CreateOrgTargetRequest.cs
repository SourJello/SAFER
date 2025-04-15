using System.Text.Json.Serialization;

public class CreateOrgTargetRequest
{
    [JsonPropertyName("satelliteTargetId")]
    public required string SatelliteTargetId { get; set; }

    [JsonPropertyName("revisitRateMinutes")]
    public int? RevisitRateMinutes { get; set; } = 1; // Default to 1 if needed
}