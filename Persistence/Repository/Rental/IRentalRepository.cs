using System.Threading.Tasks;
using Vidly.Core.DbModels;

namespace Vidly.Persistence
{
	public interface IRentalRepository
	{
		Task AddRental(RentalDbModel rentalDbModel);
	}
}