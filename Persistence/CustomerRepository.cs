using Angular2_Core_Vidly.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Controllers.ApiModels;
using Vidly.Core.DbModels;

namespace Vidly.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly VidlyDbContext dBContext;
        public CustomerRepository(VidlyDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<CustomerDbModel>> GetCustomers()
        {
            return await this.dBContext.Customer
                .Include(c => c.MembershipType)
                .ToListAsync();
        }

        public async Task<CustomerDbModel> GetCustomers(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await this.dBContext.Customer.SingleOrDefaultAsync(c => c.Id == id);

            return await this.dBContext.Customer
                .Include(c => c.MembershipType)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public void AddCustomer(CustomerDbModel customerDbModel)
        {
            dBContext.Customer.Add(customerDbModel);
        }

        public void RemoveCustomer(CustomerDbModel customerDbModel)
        {
            dBContext.Remove(customerDbModel);
        }
    }
}
