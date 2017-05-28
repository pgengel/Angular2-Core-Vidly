using System.Threading.Tasks;

namespace Angular2_Core_Vidly.Core.ApiModels
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}