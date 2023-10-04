namespace Minimal_API.Logic
{
    public interface IMovieService
    {
        Task Delete(int id);
        Task<List<Movie>> GetAll();

        Task<Movie> GetById(int id);
        Task Insert(Movie movie);
    }
}
