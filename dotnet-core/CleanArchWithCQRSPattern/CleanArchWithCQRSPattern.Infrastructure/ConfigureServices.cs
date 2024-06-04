using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchWithCQRSPattern.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogDbContext>(opt =>
        {
            opt.UseSqlite(configuration.GetConnectionString("BlogDbContext") ?? throw new InvalidOperationException("Connectionstring 'BlogDbContext' not found!"));
        });

//services.AddTransient<IBlogRepository,BlogRepository>();
        return services;
    }
}
