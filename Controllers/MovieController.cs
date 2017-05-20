using System.Collections.Generic;
using System.Threading.Tasks;
using Angular2_Core_Vidly.Controllers.ApiModels;
using Angular2_Core_Vidly.Core.DbModels;
using Angular2_Core_Vidly.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> GetMovies()
        {
            var moviesDb = await this.context.Movie.ToListAsync();
            
            if (moviesDb == null)
                return NotFound();

            var moviesApi = mapper.Map<List<MovieDbModel>, List<MovieApiModel>>(moviesDb);

            return Ok(moviesDb);
        }

    }
}