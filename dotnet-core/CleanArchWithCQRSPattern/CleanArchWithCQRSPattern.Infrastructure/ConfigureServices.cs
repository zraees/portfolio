
using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using CleanArchWithCQRSPattern.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
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

        services.AddDbContext<UserIdentityDbContext>(opt =>
        {
            opt.UseSqlite(configuration.GetConnectionString("IdentityDbContext") ?? throw new InvalidOperationException("Connectionstring 'IdentityDbContext' not found!"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IBlogRepository, BlogRepository>();

        services.AddAuthentication();

        // register UserManager etc services related to Asp.Net Core Identity
        var identityBuilder = services.AddIdentityCore<ApplicationUser>();
        identityBuilder = new IdentityBuilder(identityBuilder.UserType, identityBuilder.Services);
        identityBuilder.AddEntityFrameworkStores<UserIdentityDbContext>().AddDefaultTokenProviders();
        identityBuilder.AddSignInManager<SignInManager<ApplicationUser>>();

        return services;
    }
}
