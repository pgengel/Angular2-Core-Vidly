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
    //[Route("/api/customer")]
    public class CustomerController : Controller
    {
        private readonly VidlyDbContext context;
        private readonly IMapper mapper;

        public CustomerController(VidlyDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("/api/customers")]
        public async Task<ActionResult> GetCustomers()
        {
            var customersDb = await this.context.Customer.ToListAsync();
            if(customersDb == null)
                return NotFound();
            var customersApi = mapper.Map<List<CustomerDbModel>, List<CustomerApiModel>>(customersDb);
            return Ok(customersDb);
        }

        [HttpGet("/api/customers/new")]
        public async Task<IActionResult> getMembershipType()
        {
            var membershipTypeDb = await this.context.MembershipType.ToListAsync();

            if(membershipTypeDb == null)
                return NotFound();

            var membershipTypeApi = mapper.Map<List<MembershipTypeDbModel>, List<MembershipTypeApiModel>>(membershipTypeDb);

            return Ok(membershipTypeDb);
        }
    }
}