using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context is matching Db files and project classes...
    public class CarContext:DbContext
    {
        //we are selecting the which database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host = localhost; Username = postgres; Password = 1234; Database = RentCarDB; Pooling = true;");
            //Connection String..
            //for time enable to working with together time.
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
        //which object in sql server match which object in project we are doint it
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Core.Entities.Concrete.User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



    }
}
