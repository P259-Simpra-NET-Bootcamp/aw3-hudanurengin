using Microsoft.EntityFrameworkCore;
using Simprahafta3odev.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simprahafta3odev.Persistence.Contexts
{
    public class Simprahafta3odevDbContext : DbContext
    {
        public Simprahafta3odevDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
