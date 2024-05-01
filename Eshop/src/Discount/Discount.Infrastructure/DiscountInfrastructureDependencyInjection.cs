using Discount.Application.Abstractions;
using Discount.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure
{
    public static class DiscountInfrastructureDependencyInjection
    {
        public static IServiceCollection AddDiscountInfrastructureDepencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDiscountDbContext, DiscountDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
