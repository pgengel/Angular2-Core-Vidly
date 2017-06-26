using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Vidly.Core.DbModels;
using Vidly.Core.Factory;

namespace Vidly.Persistence
{
    public class RentalRepository : IRentalRepository
	{
	    private readonly IDbConnectionFactory _connectionFactory;
	    private const string connectionString = "server=DESKTOP-QFSTPSK; database=Vidly; user id=test; password=test";
	    internal const string ProcAddRental = "dbo.pr_AddRental @CustomerId @MovieId";

		public RentalRepository(IDbConnectionFactory connectionFactory)
	    {
		    _connectionFactory = connectionFactory;
	    }

	    public async Task AddRental(RentalDbModel rentalDbModel)
	    {
		    using (var conn = await _connectionFactory.OpenAsync(connectionString))
		    {
			    var p = new DynamicParameters();
				p.Add("@CustomerId", rentalDbModel.CustomerId);
				p.Add("@MovieId", rentalDbModel.Movies);
			    await conn.QueryAsync<int>(ProcAddRental, p);
		    }    
	    }
    }
}
