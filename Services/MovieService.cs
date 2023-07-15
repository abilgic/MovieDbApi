using Hangfire.Common;
using MovieDbApi.Repository;

namespace MovieDbApi.Services
{
    public class MovieService : Repository<Movie>, IMovieService
    {

        public MovieService(MovieDbContext context) : base(context)
        {

        }

        public async Task<int> AddMovie(MovieModel MovieModel)
        {
            try
            {
                var Movie = new Movie
                {
                    Name = MovieModel.Name,
                    Description = MovieModel.Description,
                    CreateDate = DateTime.Now
                };

                var result = await Add(Movie);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> GetList()
        {
            return await GetAll();
        }

        public async Task<int> DeleteMovie(int Id)
        {
            try
            {
                var Movieitem = await GetById(Id);

                var result = await Remove(Movieitem);
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Movie> GetMovie(int Id)
        {
            var Movieitem = await GetById(Id);
            return Movieitem;
        }

        public async Task<int> UpdateMovie(MovieModel MovieModel)
        {
            try
            {
                var Movieitem = await GetById(MovieModel.Id);
                Movieitem.Name = MovieModel.Name;
                Movieitem.Description = MovieModel.Description;
                Movieitem.CreateDate = DateTime.Now;

                var result = await UpdateAsync(Movieitem);
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
