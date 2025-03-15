using Cars_Web.cars.model;
using Microsoft.EntityFrameworkCore;

namespace Cars_Web.data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Car> Cars
        {

            get;set;
        }







        











    }
}
