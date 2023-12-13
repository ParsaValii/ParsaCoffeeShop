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
        public ParsaDbContext(DbContextOptions<ParsaDbContext> options) : base(options) {}
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}