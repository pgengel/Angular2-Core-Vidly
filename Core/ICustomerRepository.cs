using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vidly.Core.DbModels;

namespace Vidly.Persistence
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDbModel>> GetCustomers();
        Task<CustomerDbModel> GetCustomers(int id, bool includeRelated = true);
        Task<List<MembershipTypeDbModel>> GetMembershipType();
        void AddCustomer(CustomerDbModel customerDbModel);
        void RemoveCustomer(CustomerDbModel customerDbModel);
    }
}