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
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepo;

        public MovieController(IUnitOfWork uow, 
            IMovieRepository movieRepo, 
            IMapper mapper)
        {
            this._mapper = mapper;
            this._movieRepo = movieRepo;
        }

        [HttpGet("/api/movies")]
        public async Task<IActionResult> GetMovies()
        {
            var moviesDb = await _movieRepo.GetMoviesAsync();
            
            if (moviesDb == null)
                return NotFound();

            var moviesApi = this._mapper.Map<List<MovieDbModel>, List<MovieApiModel>>(moviesDb);

            return Ok(moviesApi);
        }


        [HttpGet("/api/movies/{id}")]
        public async Task<IActionResult> GetMovies(int id)
        {
            var moviesDb = await _movieRepo.GetMovieAsync(id);

            if (moviesDb == null)
                return NotFound();

            var moviesApi = this._mapper.Map<MovieDbModel, MovieApiModel>(moviesDb);

            return Ok(moviesApi);
        }

        [HttpPost("/api/movies")]
        public async Task<IActionResult> CreateMovies([FromBody] MovieApiModel movieApiModel)
        {   
            if (movieApiModel == null)
                return BadRequest();

            var moviesDb = this._mapper.Map<MovieApiModel, MovieDbModel>(movieApiModel);
            await _movieRepo.AddMovieAsync(moviesDb);

            var result = this._mapper.Map<MovieDbModel, MovieApiModel>(moviesDb);

            return Ok(result);
        }

        [HttpPut("/api/movies/{id}")]
        public async Task<IActionResult> UpdateMovies(int id, [FromBody] MovieApiModel movieApiModel)
        {
            if (movieApiModel == null)
                return BadRequest(ModelState);

            var movieDbModel = await _movieRepo.GetMovieAsync(id);

            _mapper.Map<MovieApiModel, MovieDbModel>(movieApiModel, movieDbModel);

            var result = _mapper.Map<MovieDbModel, MovieApiModel>(movieDbModel);

            return Ok(result);
        }

        [HttpDelete("/api/movies/{id}")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var moviesDb = await _movieRepo.GetMovieAsync(id);
            
            if (moviesDb == null)
                return NotFound();

            await _movieRepo.RemoveMovieAsync(moviesDb);

            return Ok(id);
        }

        [HttpGet("/api/genre")]
        public async Task<IActionResult> GetGenre()
        {
            var genreDb = await _movieRepo.GetGenreAsync();
            
            if (genreDb == null)
                return NotFound();

            var genreApi = this._mapper.Map<List<GenreDbModel>, List<GenreApiModel>>(genreDb);

            return Ok(genreApi);
        }

    }
}