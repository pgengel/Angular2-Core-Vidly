using Angular2_Core_Vidly.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Vidly.Core.DbModels;
using Vidly.Core.Factory;

namespace Vidly.Persistence
{
    public class MovieRepository : IMovieRepository
    {
	    private const string connectionString = "server=DESKTOP-QFSTPSK; database=Vidly; user id=test; password=test";

	    private readonly IDbConnectionFactory _connectionFactory;
	    internal const string ProcUpdateMovie = "dbo.UpdateMovie @MovieId @DateAdded, @GenreId, @Name, @NumberAvailable, @NumberInStock, @ReleaseDate, @RentalDbModelId";
	    internal const string ProcAddMovie = "dbo.pr_AddMovie @DateAdded, @GenreId, @Name, @NumberAvailable, @NumberInStock, @ReleaseDate, @RentalDbModelId";
	    internal const string ProcGetMovies = "dbo.pr_GetMovies";
	    internal const string ProcDeleteMovie = "dbo.pr_DeleteMovie @MovieId";
	    internal const string ProcGetGenre = "dbo.pr_GetGenre";
	    internal const string ProcGetMovie = "dbo.pr_GetMovie @MovieId";

	    public MovieRepository(
			IDbConnectionFactory connectionFactory)
	    {
		    _connectionFactory = connectionFactory;
	    }
        public async Task<List<MovieDbModel>> GetMoviesAsync()
        {
	        using (var conn = await _connectionFactory.OpenAsync(connectionString))
	        {
		        return (await conn.QueryAsync<MovieDbModel>(ProcGetMovies)).ToList();
	        }
        }

        public async Task<List<GenreDbModel>> GetGenreAsync()
        {
	        using (var conn = await _connectionFactory.OpenAsync(connectionString))
	        {
		        return (await conn.QueryAsync<GenreDbModel>(ProcGetGenre)).ToList();
	        }
        }

        public async Task<MovieDbModel> GetMovieAsync(int id)
        {
	        using (var conn = await _connectionFactory.OpenAsync(connectionString))
	        {
		        var p = new DynamicParameters();
				p.Add("@MovieId", id);
		        return (await conn.QueryAsync<MovieDbModel>(ProcGetMovie, p)).SingleOrDefault();
	        }
        }

        public async Task AddMovieAsync(MovieDbModel movieDbModel)
        {
	        using (var conn = await _connectionFactory.OpenAsync(connectionString))
	        {
				var p = new DynamicParameters();
				p.Add("@DateAdded", movieDbModel.DateAdded);
				p.Add("@GenreId", movieDbModel.GenreId);
				p.Add("@Name", movieDbModel.Name);
				p.Add("@NumberAvailable", movieDbModel.NumberAvailable);
				p.Add("@NumberInStock", movieDbModel.NumberInStock);
				p.Add("@ReleaseDate", movieDbModel.ReleaseDate);
		        await conn.QueryAsync<int>(ProcAddMovie, p);
	        }
        }

	    public async Task UpdateMovieAsync(MovieDbModel movieDbModel)
	    {
		    using (var conn = await _connectionFactory.OpenAsync(connectionString))
		    {
			    var p = new DynamicParameters();
			    p.Add("@MovieId", movieDbModel.Id);
			    p.Add("@DateAdded", movieDbModel.DateAdded);
			    p.Add("@GenreId", movieDbModel.GenreId);
			    p.Add("@Name", movieDbModel.Name);
			    p.Add("@NumberAvailable", movieDbModel.NumberAvailable);
			    p.Add("@NumberInStock", movieDbModel.NumberInStock);
			    p.Add("@ReleaseDate", movieDbModel.ReleaseDate);
				await conn.QueryAsync(ProcUpdateMovie, p);
		    }
	    }

	    public async Task RemoveMovieAsync(MovieDbModel movieDbModel)
        {
	        using (var conn = await _connectionFactory.OpenAsync(connectionString))
	        {
				var p = new DynamicParameters();
				p.Add("@MovieId", movieDbModel.Id);
		        await conn.QueryAsync<int>(ProcDeleteMovie, p);
	        }
        }
    }
}
