using System;
using Angular2_Core_Vidly.Core.ApiModels;
using System.Threading.Tasks;

namespace Angular2_Core_Vidly.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VidlyDbContext vidlyDbContext;
        public UnitOfWork(VidlyDbContext vidlyDbContext)
        {
            this.vidlyDbContext = vidlyDbContext;
        }
        public async Task CompleteAsync()
        {
            await vidlyDbContext.SaveChangesAsync();
        }
    }
}