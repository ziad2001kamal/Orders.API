using Microsoft.Extensions.DependencyInjection;
using Orders.Infrastructure.Services.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Extentions
{
    public static class ServiceContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services) {
        services.AddTransient<ICategoryService, CategoryService>();
        //services.AddTransient<IUserService, User>();

            return services;
        }
    }
}
