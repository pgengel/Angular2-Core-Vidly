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
        public async Task<IActionResult> GetCustomers()
        {
            var customersDb = await this.context.Customer.Include(c => c.MembershipType).ToListAsync();

            if(customersDb == null)
                return NotFound();

            var customersApi = mapper.Map<List<CustomerDbModel>, List<CustomerApiModel>>(customersDb);

            return Ok(customersApi);
        }


        [HttpGet("/api/customers/{id}")]
        public async Task<IActionResult> GetCustomers(int id)
        {
            var customersDb = await this.context.Customer.Include(c => c.MembershipType).SingleOrDefaultAsync(c => c.Id == id);

            if (customersDb == null)
                return NotFound(id);

            var customersApi = mapper.Map<CustomerDbModel, CustomerApiModel>(customersDb);

            return Ok(customersApi);
        }


        [HttpGet("/api/customers/getMembershipType")]
        public async Task<IActionResult> GetMembershipType()
        {
            var membershipTypeDb = await this.context.MembershipType.ToListAsync();

            if(membershipTypeDb == null)
                return NotFound();

            var membershipTypeApi = mapper.Map<List<MembershipTypeDbModel>, List<MembershipTypeApiModel>>(membershipTypeDb);

            return Ok(membershipTypeApi);
        }


        [HttpPost("/api/customers")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerApiModel customerApiModel)
        {
            if (customerApiModel == null)
                return BadRequest(ModelState);

            var customerDbModel = mapper.Map<CustomerApiModel, CustomerDbModel>(customerApiModel);

            context.Customer.Add(customerDbModel);
            await context.SaveChangesAsync();

            var result = mapper.Map<CustomerDbModel, CustomerApiModel>(customerDbModel);

            return Ok(result);
        }

        [HttpDelete("/api/customers/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerDbModel = await context.Customer.FindAsync(id);

            if (customerDbModel == null)
                return NotFound(id);    

            context.Remove(customerDbModel);
            await context.SaveChangesAsync();

            return Ok(id);
        }


        [HttpPut("/api/customers/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerApiModel customerApiModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var customerDbModel = mapper.Map<CustomerApiModel, CustomerDbModel>(customerApiModel);

            //context.Customer.Add(customerDbModel);
            //await context.SaveChangesAsync();

            //var result = mapper.Map<CustomerDbModel, CustomerApiModel>(customerDbModel);

            return Ok(customerApiModel);
        }
    }
}