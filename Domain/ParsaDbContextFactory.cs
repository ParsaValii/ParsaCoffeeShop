using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ParsaDbContextFactory : IDesignTimeDbContextFactory<ParsaDbContext>
    {
        public ParsaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ParsaDbContext>();
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Server=localhost;Database=ParsaCoffeeShopDb;Port=5432;User Id=postgres;Password=postgres");

            return new ParsaDbContext(optionsBuilder.Options);
        }
    }
}
