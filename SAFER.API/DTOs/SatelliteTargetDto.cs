public class SatelliteTargetDto
{
    public required string Id { get; set; }
    public required string TleName { get; set; }
    public required string NoradId { get; set; }
    public required string OrbitType { get; set; }
    public required double Inclination { get; set; }
    public required string TrackingStatus { get; set; }
}