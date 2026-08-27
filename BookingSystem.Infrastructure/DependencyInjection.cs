using BookingSystem.Application.Interfaces;
using BookingSystem.Application.Interfaces.Repositories;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.Repositories;
using BookingSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Generic repository 
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Repositories
            services.AddScoped<IServiceRepository, ServiceRepository>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}