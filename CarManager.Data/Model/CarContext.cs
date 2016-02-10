using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CarManager.Data.Model
{
    public class CarContext:DbContext
    {
        public CarContext():base("name=RestServiceDbConnection")
        {
           // Database.SetInitializer<CarContext>(new CreateDatabaseIfNotExists<CarContext>());
        }

        public DbSet<Car> Cars { set; get; }
    }
}
