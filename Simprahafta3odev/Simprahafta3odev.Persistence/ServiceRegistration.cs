using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Simprahafta3odev.Persistence.Contexts;
using Simprahafta3odev.Application.Repositories.Products;
using Simprahafta3odev.Application.Repositories.Categories;
using Simprahafta3odev.Application.Repositories;



namespace Simprahafta3odev.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<Simprahafta3odevDbContext>(options => options.UseSqlServer(Configurations.ConnectionString), ServiceLifetime.Scoped);
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
