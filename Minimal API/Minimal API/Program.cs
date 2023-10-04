var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<Movie> movies = new()
{
    new() {Id = 1, Rating = 5, Title = "Shrek"},
    new() {Id = 2, Rating = 1, Title = "Inception"},
    new() {Id = 3, Rating = 3, Title = "Jaws"},
    new() {Id = 4, Rating = 1, Title = "The Green Lantern"},
    new() {Id = 5, Rating = 5, Title = "The Matrix" }
};

app.MapGet("/api/Movies", () =>
{
    return Results.Ok(movies);
});


app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Rating { get; set; }

}