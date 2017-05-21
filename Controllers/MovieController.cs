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
            var moviesDb = await this.context.Movie.ToListAsync();
            
            if (moviesDb == null)
                return NotFound();

            var moviesApi = this.mapper.Map<List<MovieDbModel>, List<MovieApiModel>>(moviesDb);

            return Ok(moviesApi);
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