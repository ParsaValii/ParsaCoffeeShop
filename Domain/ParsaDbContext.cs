using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ParsaDbContext : DbContext
    {
        public ParsaDbContext() {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(
                "Server=localhost;Database=Parsadb;Integrated Security=True;TrustServerCertificate=True;"
            );
        }
        public ParsaDbContext(DbContextOptions<ParsaDbContext> options) : base(options) {}
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}