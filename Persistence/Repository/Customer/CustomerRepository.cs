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
	    internal const string ProcAddCustomer = "dbo.pr_AddCustomer @customerMemebershipTypeId, @customerName, @customerSubscription, @customerBirthday";

		private const string connectionString = "server=DESKTOP-QFSTPSK; database=Vidly; user id=test; password=test";
	    private readonly IDbConnectionFactory _connectionFactory;

	    public CustomerRepository(
	        IDbConnectionFactory connectionFactory
			)
	    {
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

        public async Task AddCustomer(CustomerDbModel customerDbModel)
        {
	        using (var conn = await _connectionFactory.OpenAsync(connectionString))
	        {
		        var p = new DynamicParameters();
				p.Add("@customerMemebershipTypeId", customerDbModel.MembershipTypeId);
		        p.Add("@customerName", customerDbModel.Name);
		        p.Add("@customerSubscription", customerDbModel.isSubscribedToNewsLetter);
		        p.Add("@customerBirthday", customerDbModel.Birthday);
		        await conn.QueryAsync<int>(ProcAddCustomer, p);
	        }
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
