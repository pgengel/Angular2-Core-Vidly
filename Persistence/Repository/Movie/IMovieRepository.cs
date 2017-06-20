using System.Collections.Generic;
using System.Threading.Tasks;
using Vidly.Core.DbModels;

namespace Vidly.Persistence
{
    public interface IMovieRepository
    {
        Task<List<MovieDbModel>> GetMoviesAsync();
		Task<MovieDbModel> GetMovieAsync(int id);
	    Task AddMovieAsync(MovieDbModel movieDbModel);
	    Task UpdateMovieAsync(MovieDbModel movieDbModel);
		Task RemoveMovieAsync(MovieDbModel movieDbModel);
        Task<List<GenreDbModel>> GetGenreAsync();
    }
}