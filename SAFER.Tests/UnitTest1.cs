using Xunit;
using SAFER.API.Services;

public class OurSkyServiceTests
{
    [Fact]
    public void CanConstructOurSkyService()
    {
        var httpClient = new HttpClient();
        var service = new OurSkyService(httpClient);
        Assert.NotNull(service);
    }
}