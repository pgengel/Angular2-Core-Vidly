using Angular2_Core_Vidly.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Controllers.ApiModels;
using Vidly.Core.DbModels;
using Vidly.Core.Factory;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Vidly.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
	    internal const string ProcGetCustomers = "dbo.pr_GetCustomers";
	    internal const string ProcGetCustomer = "dbo.pr_GetCustomer @customerId";
	    internal const string ProcDeleteCustomer = "dbo.pr_DeleteCustomer @customerId";

		private const string connectionString = "server=DESKTOP-QFSTPSK; database=Vidly; user id=test; password=test";
		private readonly VidlyDbContext dBContext;
	    private readonly IDbConnectionFactory _connectionFactory;

	    public CustomerRepository(
			VidlyDbContext dBContext,
	        IDbConnectionFactory connectionFactory
			)
	    {
		    this.dBContext = dBContext;
		    _connectionFactory = connectionFactory;
	    }

	    public async Task<List<CustomerDbModel>> GetCustomersAsync()
	    {
		    using (var conn = await _connectionFactory.OpenAsync(connectionString))
		    {
			    return (await conn.QueryAsync<CustomerDbModel>(ProcGetCustomers)).ToList();
		    }
		}

		public async Task<CustomerDbModel> GetCustomersAsync(int id)
        {
	        using (var conn = await _connectionFactory.OpenAsync(connectionString))
	        {
				var p = new DynamicParameters();
				p.Add("@customerId", id);
				return (await conn.QueryAsync<CustomerDbModel>(ProcGetCustomer, p)).SingleOrDefault();
	        }
        }

        public async Task<List<MembershipTypeDbModel>> GetMembershipType()
        {
            return await dBContext.MembershipType.ToListAsync();
        }

        public void AddCustomer(CustomerDbModel customerDbModel)
        {
            dBContext.Customer.Add(customerDbModel);
        }

        public async Task RemoveCustomer(CustomerDbModel customerDbModel)
        {
	        using (var conn = await _connectionFactory.OpenAsync(connectionString))
	        {
		        var p = new DynamicParameters();
				p.Add("@customerId", customerDbModel.Id);
		        await conn.QueryAsync<int>(ProcDeleteCustomer, p);
	        }
        }
    }
}
