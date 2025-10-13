using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataEF
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(): base("MyDBConnections")
        {      
        }
        public DbSet<MyProjectDataEF.Country> Countries { get; set; }
        public DbSet<MyProjectDataEF.City> Cities { get; set; }
        public DbSet<MyProjectDataEF.District> Districts { get; set; }
        public DbSet<MyProjectDataEF.Neighborhood> Neighborhoods { get; set; }
    }


}
