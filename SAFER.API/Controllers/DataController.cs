using Microsoft.AspNetCore.Mvc;
using SAFER.API.Services;

namespace SAFER.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly OurSkyService _ourSky;
    private readonly SpaceTrackService _spaceTrack;
    private readonly SatNOGSService _satNOGS;

    public DataController(
        OurSkyService ourSky,
        SpaceTrackService spaceTrack,
        SatNOGSService satNOGS)
    {
        _ourSky = ourSky;
        _spaceTrack = spaceTrack;
        _satNOGS = satNOGS;
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok("DataController is online and ready to ingest.");
    }

    [HttpGet("oursky")]
    public async Task<IActionResult> GetOurSkyData()
    {
        var result = await _ourSky.GetSatelliteTargetsAsync();
        return Ok(result);
    }
[HttpGet("oursky/satellite-targets")]
public async Task<IActionResult> GetAvailableTargets()
{
    var rawTargets = await _ourSky.GetSatelliteTargetsAsync();

    var result = rawTargets
        .Select(t => new SatelliteTargetDto
        {
            Id = t.Id,
            TleName = t.TleName,
            NoradId = t.NoradId,
            OrbitType = t.OrbitType,
            Inclination = t.Inclination,
            TrackingStatus = t.TrackingStatus
        })
        .ToList();

    return Ok(result);
}
    [HttpPost("organization-targets")]
    public async Task<IActionResult> CreateOrgTarget([FromBody] CreateOrgTargetRequest request)
    {
        var success = await _ourSky.CreateOrgTargetAsync(request);
        return success ? Ok() : StatusCode(500, "Failed to create org target.");
    }

    // Future endpoints:
    // [HttpGet("oursky")]
    // public async Task<IActionResult> GetOurSkyData() { ... }

    // [HttpGet("spacetrack")]
    // public async Task<IActionResult> GetSpaceTrackData() { ... }

    // [HttpGet("satnogs")]
    // public async Task<IActionResult> GetSatNOGSData() { ... }
}