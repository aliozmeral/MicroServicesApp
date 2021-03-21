using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Data
{
    public class DAPContext :DbContext
    {
        public DAPContext(DbContextOptions options) : base(options)
        {
        }
        public DAPContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog =MicroserviceExampleDB;Trusted_Connection=True;MultipleActiveResultSets = true");
        }
    }
}
