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

        [HttpGet("/api/rentals")]
        public async Task<IActionResult> GetRentals()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rentalDbModel = await context.Rental
                .Include(r => r.Customer)
                    .ThenInclude(r => r.MembershipType)
                //.Include(r => r.Movies.ToList())
                .ToListAsync();

            if (rentalDbModel == null)
                return NotFound(ModelState);

            var rentalApiModel = mapper.Map<List<RentalDbModel>, List<SaveRentalApiModel>>(rentalDbModel);

            return Ok(rentalApiModel);
        }

        [HttpGet("/api/rentals/{id}")]
        public async Task<IActionResult> GetRentals(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rentalDbModel = await context.Rental
                .Include(r => r.Customer)
                //.Include(r => r.Movies)
                .SingleOrDefaultAsync(r => r.Id == id);

            if (rentalDbModel == null)
                return NotFound(ModelState);

            var rentalApiModel = mapper.Map<RentalDbModel, SaveRentalApiModel>(rentalDbModel);

            return Ok(rentalApiModel);
        }

        [HttpPost("/api/rentals")]
        public async Task<IActionResult> CreateRental([FromBody]SaveRentalApiModel rentalApiModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var renetalDbModel = mapper.Map<SaveRentalApiModel, RentalDbModel>(rentalApiModel);

            context.Rental.Add(renetalDbModel);
            await context.SaveChangesAsync();
            var result = mapper.Map<RentalDbModel, SaveRentalApiModel>(renetalDbModel);

            return Ok(result);
        }

        [HttpPut("/api/rental/{id}")]
        public async Task<IActionResult> UpdateRental(int id, [FromBody]SaveRentalApiModel rentalApiModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var renetalDb = await context.Rental.Include(r => r.Movies).SingleOrDefaultAsync(r => r.Id == id);

            if (renetalDb == null)
                return NotFound();

            mapper.Map<SaveRentalApiModel, RentalDbModel>(rentalApiModel, renetalDb);

            //await context.SaveChangesAsync();
            var result = mapper.Map<RentalDbModel, SaveRentalApiModel>(renetalDb);

            return Ok(result);
        }
    }
}
