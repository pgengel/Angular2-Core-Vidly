using Microsoft.EntityFrameworkCore;
using Vidly.Core.DbModels;

namespace Angular2_Core_Vidly.Persistence
{
    public class VidlyDbContext : DbContext //Must inherent from the DbContext
    {
        //Add the Db Models
        public DbSet<CustomerDbModel> Customer { get; set; }
        public DbSet<MembershipTypeDbModel> MembershipType { get; set; }
        public DbSet<MovieDbModel> Movie { get; set; }
        public DbSet<GenreDbModel> Genre { get; set; }
        public DbSet<RentalDbModel> Rental { get; set; }
        
        //In start-Up, services.AddDbContext<VidlyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"))); //add using Microsoft.EntityFrameworkCore;
        public VidlyDbContext(DbContextOptions<VidlyDbContext> options): base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerMovieDbModel>().HasKey(cm => new { cm.CustomerId, cm.MovieId});
        }
    }
}