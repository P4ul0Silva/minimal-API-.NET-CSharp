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

// cria lista de objetos da classe Movie
List<Movie> movies = new()
{
    new() {Id = 1, Rating = 5, Title = "Shrek"},
    new() {Id = 2, Rating = 1, Title = "Inception"},
    new() {Id = 3, Rating = 3, Title = "Jaws"},
    new() {Id = 4, Rating = 1, Title = "The Green Lantern"},
    new() {Id = 5, Rating = 5, Title = "The Matrix" }
};

// rota exemplo get; retorna todos os items de Movie
app.MapGet("/api/Movies", () =>
{
    return Results.Ok(movies);
});

// rota get: retorna apenas um elemento Movie
app.MapGet("/api/Movies/{id:int}", (int id) =>
{
    // usado método single para retornar apenas um elemento
    // basicamente um filtro usando syntaxe de arrow functions
    return Results.Ok(movies.Single(movie => movie.Id == id));
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