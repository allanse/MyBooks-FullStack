using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBooks.Domain.Interfaces;
using MyBooks.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}