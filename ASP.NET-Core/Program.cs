using learn.Data;
using Microsoft.EntityFrameworkCore;

// var keyword will tell the compiler
// to auto infer type of the variable
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // allow API discoverbility
builder.Services.AddSwaggerGen(); // interactive API development
builder.Services.AddControllers(); // this needs to be added so that the donet compiler can read the controller
builder.Services.AddDbContext<IssueDbContext>
(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("SqlServer"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//If clients send requests to "http://..."
//It will be redirect to "https://..."
app.UseHttpsRedirection();

app.MapControllers(); // this needs to be added so that the donet compiler can read the controller

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
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
