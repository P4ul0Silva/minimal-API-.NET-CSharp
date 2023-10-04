using Minimal_API.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configura Inje��o de Depend�ncias
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// cria lista de objetos da classe Movie
// implementa��o pode ser removida ap�s o uso da Inje��o de Depend�ncias (DI)
//MovieService movieService = new();

app.UseHttpsRedirection();

// rota exemplo get; requisi��o retorna todos os items de Movie
// Inje��o da interface IMovieService no M�todo
// Adiciona async para as callbakcs e await para os m�todos de movieService
app.MapGet("/api/movies", async (IMovieService movieService) =>
{
    return Results.Ok(await movieService.GetAll());
});

// rota get: requisi��o retorna apenas um elemento Movie
app.MapGet("/api/movies/{id:int}", async (int id, IMovieService movieService) =>
{ 
    return Results.Ok(await movieService.GetById(id));
});


// rota post; requisi��o para criar objeto da classe movies
app.MapPost("/api/movies/", async (Movie movie, IMovieService movieService) =>
{
    await movieService.Insert(movie);

    // debug
    return Results.Ok(await movieService.GetAll());
});


// rota delete; requisi��o para deletar objetos movie
app.MapDelete("/api/movies/{id:int}", async (int id, IMovieService movieService) =>
{
    await movieService.Delete(id);

    return Results.Ok(await movieService.GetAll());
});


// rota put; requisi��o para atualizar objeto movie
//app.MapPut("/api/movies", (Movie movie) =>
//{
//    Movie foundMovie = movies.Single(x => x.Id == movie.Id);

//    foundMovie.Rating = movie.Rating;

//    return Results.Ok(movies);
//});


app.Run();