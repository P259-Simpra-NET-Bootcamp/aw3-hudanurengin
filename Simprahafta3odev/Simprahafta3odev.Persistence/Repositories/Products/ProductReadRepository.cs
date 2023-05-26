using Simprahafta3odev.Application.Repositories.Categories;
using Simprahafta3odev.Domain.Entities;
using Simprahafta3odev.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simprahafta3odev.Application.Repositories.Products
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(Simprahafta3odevDbContext context) : base(context)
        {
        }
    }
}
