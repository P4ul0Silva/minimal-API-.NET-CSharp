namespace Minimal_API.Logic
{

    // conecta a interface com a classe IMovieService
    public class MovieService: IMovieService
    {
        private List<Movie> _movies = new()
        {
            new() {Id = 1, Rating = 5, Title = "Shrek"},
            new() {Id = 2, Rating = 1, Title = "Inception"},
            new() {Id = 3, Rating = 3, Title = "Jaws"},
            new() {Id = 4, Rating = 1, Title = "The Green Lantern"},
            new() {Id = 5, Rating = 5, Title = "The Matrix" },
        };

        public void Delete(int id)
        {
            _movies.Remove(_movies.Single(x=> x.Id == id));
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
            // usado método single para retornar apenas um elemento
            // basicamente um filtro usando syntaxe de arrow functions
            return _movies.Single(x=> x.Id == id);
        }

        public void Insert(Movie movie)
        {
            _movies.Add(movie);
        }
    }
}
