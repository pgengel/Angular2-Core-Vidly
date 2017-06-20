using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vidly.Core.DbModels;

namespace Vidly.Persistence
{
    public interface ICustomerRepository
    {
	    Task<List<CustomerDbModel>> GetCustomersAsync();
		Task<CustomerDbModel> GetCustomersAsync(int id);
        Task AddCustomerAsync(CustomerDbModel customerDbModel);
        Task RemoveCustomerAsync(CustomerDbModel customerDbModel);
	    Task UpdateCustomerAsync(CustomerDbModel customerDbModel);

    }
}