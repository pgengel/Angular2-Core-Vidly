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
    //[Route("/api/customer")]
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepo;
        private readonly IUnitOfWork _uow;

        public CustomerController(IMapper mapper, 
            ICustomerRepository customerRepo,
            IUnitOfWork uow)
        {
            this._mapper = mapper;
            this._customerRepo = customerRepo;
            this._uow = uow;
        }

        [HttpGet("/api/customers")]
        public async Task<IActionResult> GetCustomersAsync()
        {
	        var customersDb = await _customerRepo.GetCustomersAsync();

			if (customersDb == null)
                return NotFound();

            var customersApi = _mapper.Map<List<CustomerDbModel>, List<CustomerApiModel>>(customersDb);

            return Ok(customersApi);
        }


        [HttpGet("/api/customers/{id}")]
        public async Task<IActionResult> GetCustomersAsync(int id)
        {
            var customersDb = await _customerRepo.GetCustomersAsync(id);

            if (customersDb == null)
                return NotFound(id);

            var customersApi = _mapper.Map<CustomerDbModel, CustomerApiModel>(customersDb);

            return Ok(customersApi);
        }


        [HttpPost("/api/customers")]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerApiModel customerApiModel)
        {
            if (customerApiModel == null)
                return BadRequest(ModelState);

            var customerDbModel = _mapper.Map<CustomerApiModel, CustomerDbModel>(customerApiModel);

            await _customerRepo.AddCustomerAsync(customerDbModel);

            var result = _mapper.Map<CustomerDbModel, CustomerApiModel>(customerDbModel);

            return Ok(result);
        }

        [HttpDelete("/api/customers/{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerDbModel = await _customerRepo.GetCustomersAsync(id);

            if (customerDbModel == null)
                return NotFound(id);

            await _customerRepo.RemoveCustomerAsync(customerDbModel);

            return Ok(id);
        }


        [HttpPut("/api/customers/{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] CustomerApiModel customerApiModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerDbModel = await _customerRepo.GetCustomersAsync(id);

            _mapper.Map<CustomerApiModel, CustomerDbModel>(customerApiModel, customerDbModel);

			await _customerRepo.UpdateCustomerAsync(customerDbModel);

			var result = _mapper.Map<CustomerDbModel, CustomerApiModel>(customerDbModel);

            return Ok(result);
        }
    }
}