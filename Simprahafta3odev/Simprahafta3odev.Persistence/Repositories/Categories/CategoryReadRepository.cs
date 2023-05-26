using Simprahafta3odev.Persistence.Contexts;
using Simprahafta3odev.Application.Repositories;
using Simprahafta3odev.Application.Repositories.Categories;
using Simprahafta3odev.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simprahafta3odev.Application.Repositories.Categories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(Simprahafta3odevDbContext context) : base(context)
        {
        }
    }
}
