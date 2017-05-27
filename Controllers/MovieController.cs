using System.Collections.Generic;
using System.Threading.Tasks;
using Angular2_Core_Vidly.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Core.DbModels;
using Vidly.Controllers.ApiModels;

namespace Angular2_Core_Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly VidlyDbContext context;
        private readonly IMapper mapper;
        public MovieController(VidlyDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/movies")]
        public async Task<IActionResult> GetMovies()
        {
            var moviesDb = await this.context.Movie.Include(m => m.Genre).ToListAsync();
            
            if (moviesDb == null)
                return NotFound();

            var moviesApi = this.mapper.Map<List<MovieDbModel>, List<MovieApiModel>>(moviesDb);

            return Ok(moviesApi);
        }


        [HttpGet("/api/movies/{id}")]
        public async Task<IActionResult> GetMovies(int id)
        {
            var moviesDb = await this.context.Movie.Include(m => m.Genre).SingleOrDefaultAsync(m => m.GenreId == id);

            if (moviesDb == null)
                return NotFound();

            var moviesApi = this.mapper.Map<MovieDbModel, MovieApiModel>(moviesDb);

            return Ok(moviesApi);
        }

        [HttpPost("/api/movies")]
        public async Task<IActionResult> CreateMovies([FromBody] MovieApiModel movieApiModel)
        {   
            if (movieApiModel == null)
                return BadRequest();

            var moviesDb = this.mapper.Map<MovieApiModel, MovieDbModel>(movieApiModel);
            context.Add(moviesDb);
            await context.SaveChangesAsync();

            var result = this.mapper.Map<MovieDbModel, MovieApiModel>(moviesDb);

            return Ok(result);
        }

        [HttpDelete("/api/movies/{id}")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var moviesDb = await this.context.Movie.FindAsync(id);
            
            if (moviesDb == null)
                return NotFound();

            context.Movie.Remove(moviesDb);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("/api/genre")]
        public async Task<IActionResult> GetGenre()
        {
            //GenreDbModel genreDb = this.context.Genre.SingleOrDefault(x => x.Id == 1);
            List<GenreDbModel> genreDb = await this.context.Genre.ToListAsync();
            
            if (genreDb == null)
                return NotFound();

            var genreApi = this.mapper.Map<List<GenreDbModel>, List<GenreApiModel>>(genreDb);

            return Ok(genreDb);
        }

    }
}