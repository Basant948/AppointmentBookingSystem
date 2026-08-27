using BookingSystem.Application.Interfaces.Services;
using BookingSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Application Services
            services.AddScoped<IServiceService, ServiceService>();

            return services;
        }
    }
}