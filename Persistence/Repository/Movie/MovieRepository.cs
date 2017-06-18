using Angular2_Core_Vidly.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Core.DbModels;

namespace Vidly.Persistence
{
    public class MovieRepository : IMovieRepository
    {
        private readonly VidlyDbContext context;
        public MovieRepository(VidlyDbContext context)
        {
            this.context = context;
        }
        public async Task<List<MovieDbModel>> GetMovies()
        {
            return await this.context.Movie
                .Include(m => m.Genre)
                .ToListAsync();
        }

        public async Task<List<GenreDbModel>> GetGenre()
        {
            return await this.context.Genre.ToListAsync();
        }

        public async Task<MovieDbModel> GetMovies(int id, bool includedRelated = true)
        {
            if(!includedRelated)
                return await this.context.Movie
                    .SingleOrDefaultAsync(m => m.GenreId == id);

            return await this.context.Movie
                .Include(m => m.Genre)
                .SingleOrDefaultAsync(m => m.GenreId == id);
        }

        public void AddMovie(MovieDbModel movieDbModel)
        {
            this.context.Add(movieDbModel);
        }

        public void RemoveMovie(MovieDbModel movieDbModel)
        {
            this.context.Remove(movieDbModel);
        }
    }
}
