using Hangfire.Common;
using MovieDbApi.Repository;

namespace MovieDbApi.Services
{
    public interface IMovieService : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetList();
        Task<Movie> GetMovie(int Id);
        Task<int> AddMovie(MovieModel moviemodel);
        Task<int> UpdateMovie(MovieModel moviemodel);
        Task<int> DeleteMovie(int Id);
    }
}
