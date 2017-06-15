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
        Task<List<MembershipTypeDbModel>> GetMembershipType();
        void AddCustomer(CustomerDbModel customerDbModel);
        void RemoveCustomer(CustomerDbModel customerDbModel);
    }
}