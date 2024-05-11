using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Post.Application.Abstraction;
using Post.Infrastructor.Persistence;

namespace Post.Infrastructor;

public static  class AddInfrastructure
{
    public static IServiceCollection AddPostInfrustructor(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IPostModelDbContext, AbbDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}
