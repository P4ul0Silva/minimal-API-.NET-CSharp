namespace Minimal_API.Logic
{
    public interface IMovieService
    {
        void Delete(int id);
        List<Movie> GetAll();

        Movie GetById(int id);
        void Insert(Movie movie);
    }
}
