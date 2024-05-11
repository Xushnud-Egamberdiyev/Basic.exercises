using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Post.Application;

public static class PostApplicationDependensInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
