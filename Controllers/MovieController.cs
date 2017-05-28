using System.Collections.Generic;
using System.Threading.Tasks;
using Angular2_Core_Vidly.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Core.DbModels;
using Vidly.Controllers.ApiModels;
using Vidly.Persistence;
using Angular2_Core_Vidly.Core.ApiModels;

namespace Angular2_Core_Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMovieRepository movieRepo;
        private readonly IUnitOfWork uow;

        public MovieController(IUnitOfWork uow, 
            IMovieRepository movieRepo, 
            IMapper mapper)
        {
            this.mapper = mapper;
            this.movieRepo = movieRepo;
            this.uow = uow;
        }

        [HttpGet("/api/movies")]
        public async Task<IActionResult> GetMovies()
        {
            var moviesDb = await movieRepo.GetMovies();
            
            if (moviesDb == null)
                return NotFound();

            var moviesApi = this.mapper.Map<List<MovieDbModel>, List<MovieApiModel>>(moviesDb);

            return Ok(moviesApi);
        }


        [HttpGet("/api/movies/{id}")]
        public async Task<IActionResult> GetMovies(int id)
        {
            var moviesDb = await movieRepo.GetMovies(id);

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
            movieRepo.AddMovie(moviesDb);
            await uow.CompleteAsync();

            var result = this.mapper.Map<MovieDbModel, MovieApiModel>(moviesDb);

            return Ok(result);
        }

        [HttpPut("/api/movies/{id}")]
        public async Task<IActionResult> UpdateMovies(int id, [FromBody] MovieApiModel movieApiModel)
        {
            if (movieApiModel == null)
                return BadRequest(ModelState);

            var movieDbModel = await movieRepo.GetMovies(id);

            mapper.Map<MovieApiModel, MovieDbModel>(movieApiModel, movieDbModel);

            await uow.CompleteAsync();

            var result = mapper.Map<MovieDbModel, MovieApiModel>(movieDbModel);

            return Ok(result);
        }

        [HttpDelete("/api/movies/{id}")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var moviesDb = await movieRepo.GetMovies(id, includedRelated: false);
            
            if (moviesDb == null)
                return NotFound();

            movieRepo.RemoveMovie(moviesDb);

            await uow.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("/api/genre")]
        public async Task<IActionResult> GetGenre()
        {
            var genreDb = await movieRepo.GetGenre();
            
            if (genreDb == null)
                return NotFound();

            var genreApi = this.mapper.Map<List<GenreDbModel>, List<GenreApiModel>>(genreDb);

            return Ok(genreDb);
        }

    }
}