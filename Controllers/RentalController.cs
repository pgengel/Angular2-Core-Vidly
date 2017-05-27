using Angular2_Core_Vidly.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Controllers.ApiModels;
using Vidly.Core.DbModels;

namespace Vidly.Controllers
{
    public class RentalController : Controller
    {
        private readonly IMapper mapper;
        private readonly VidlyDbContext context;
        public RentalController(IMapper mapper, VidlyDbContext context)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpPost("/api/rental/new")]
        public async Task<IActionResult> CreateRental([FromBody]RentalApiModel rentalApiModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var renetalDb = mapper.Map<RentalApiModel, RentalDbModel>(rentalApiModel);

            context.Rental.Add(renetalDb);
            //await context.SaveChangesAsync();
            var result = mapper.Map<RentalDbModel, RentalApiModel>(renetalDb);

            return Ok(result);
        }

        [HttpPut("/api/rental/{id}")]
        public async Task<IActionResult> UpdateRental(int id, [FromBody]RentalApiModel rentalApiModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var renetalDb = await context.Rental.Include(r => r.Movies).SingleOrDefaultAsync(r => r.Id == id);

            if (renetalDb == null)
                return NotFound();

            mapper.Map<RentalApiModel, RentalDbModel>(rentalApiModel, renetalDb);

            //await context.SaveChangesAsync();
            var result = mapper.Map<RentalDbModel, RentalApiModel>(renetalDb);

            return Ok(result);
        }
    }
}
