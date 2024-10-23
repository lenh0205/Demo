using Main.Base;
using Main.DataAccess.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Main.Configuration
{
    public static class AppDIConfiguration
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBusinessServicesFactory, BusinessServicesFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
