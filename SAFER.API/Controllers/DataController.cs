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
    public IActionResult GetOurSkyData()
    {
        var result = await _ourSky.GetSampleObservationAsync();
        return Ok(result);
    }

    // Future endpoints:
    // [HttpGet("oursky")]
    // public async Task<IActionResult> GetOurSkyData() { ... }

    // [HttpGet("spacetrack")]
    // public async Task<IActionResult> GetSpaceTrackData() { ... }

    // [HttpGet("satnogs")]
    // public async Task<IActionResult> GetSatNOGSData() { ... }
}