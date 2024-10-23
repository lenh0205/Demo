using Main.Application.Factory;
using Main.DataAccess.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Main.Application.DendencyInjection
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
            services.AddScoped<IBusinessHandlersFactory, BusinessHandlersFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IControllerDependencies<>), typeof(ControllerDependencies<>));
            services.AddTransient<IBusinessHandlerDependencies, BusinessHandlerDependencies>();

            return services;
        }
    }
}
