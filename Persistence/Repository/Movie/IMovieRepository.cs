using System.Collections.Generic;
using System.Threading.Tasks;
using Vidly.Core.DbModels;

namespace Vidly.Persistence
{
    public interface IMovieRepository
    {
        Task<List<MovieDbModel>> GetMovies();
        Task<MovieDbModel> GetMovies(int id, bool includedRelated = true);
        void AddMovie(MovieDbModel movieDbModel);
        void RemoveMovie(MovieDbModel movieDbModel);
        Task<List<GenreDbModel>> GetGenre();
    }
}