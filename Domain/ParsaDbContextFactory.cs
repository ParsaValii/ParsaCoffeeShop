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
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=localhost;Database=Parsadb;Integrated Security=True;TrustServerCertificate=True;");

            return new ParsaDbContext(optionsBuilder.Options);
        }
    }
}
