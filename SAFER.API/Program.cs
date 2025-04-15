using SAFER.API.Services;
using System.Net.Http.Headers; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddScoped<OurSkyService>();
builder.Services.AddScoped<SpaceTrackService>();
builder.Services.AddScoped<SatNOGSService>();

var config = builder.Configuration;

//Load secret from user secrets
builder.Services.AddHttpClient<OurSkyService>(client =>
{
    client.BaseAddress = new Uri(config["OurSky:BaseUrl"]);
    client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", config["OurSky:ApiKey"]);
});

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint($"{(app.Environment.IsDevelopment() ? "" : "/")}/swagger/v1/swagger.json", "SAFER.API v1");
        options.RoutePrefix = "docs";
    });
}

app.MapControllers();
app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
