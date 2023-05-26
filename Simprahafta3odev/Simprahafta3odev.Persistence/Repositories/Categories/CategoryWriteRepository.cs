using Simprahafta3odev.Domain.Entities;
using Simprahafta3odev.Persistence.Contexts;
using Simprahafta3odev.Application.Repositories.Categories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simprahafta3odev.Application.Repositories
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(Simprahafta3odevDbContext context) : base(context)
        {
        }
    }
}
