using Minimal_API.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configura Injeção de Dependências
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// cria lista de objetos da classe Movie
// implementação pode ser removida após o uso da Injeção de Dependências (DI)
//MovieService movieService = new();

app.UseHttpsRedirection();

// rota exemplo get; requisição retorna todos os items de Movie
// Injeção da interface IMovieService no Método
// Adiciona async para as callbakcs e await para os métodos de movieService
app.MapGet("/api/movies", async (IMovieService movieService) =>
{
    return Results.Ok(await movieService.GetAll());
});

// rota get: requisição retorna apenas um elemento Movie
app.MapGet("/api/movies/{id:int}", async (int id, IMovieService movieService) =>
{ 
    return Results.Ok(await movieService.GetById(id));
});


// rota post; requisição para criar objeto da classe movies
app.MapPost("/api/movies/", async (Movie movie, IMovieService movieService) =>
{
    await movieService.Insert(movie);

    // debug
    return Results.Ok(await movieService.GetAll());
});


// rota delete; requisição para deletar objetos movie
app.MapDelete("/api/movies/{id:int}", async (int id, IMovieService movieService) =>
{
    await movieService.Delete(id);

    return Results.Ok(await movieService.GetAll());
});


// rota put; requisição para atualizar objeto movie
//app.MapPut("/api/movies", (Movie movie) =>
//{
//    Movie foundMovie = movies.Single(x => x.Id == movie.Id);

//    foundMovie.Rating = movie.Rating;

//    return Results.Ok(movies);
//});


app.Run();