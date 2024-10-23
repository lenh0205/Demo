using Main.Application.Factory;
using Main.DataAccess.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Main.Application.DendencyInjection
{
    public static class AppDIConfiguration
    {
        public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
        }

        public static void AddCustomDependencies(this IServiceCollection services)
        {
            services.AddScoped<IBusinessHandlersFactory, BusinessHandlersFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IControllerDependencies<>), typeof(ControllerDependencies<>));
            services.AddTransient<IBusinessHandlerDependencies, BusinessHandlerDependencies>();
            services.AddTransient<IRepositoryDependencies, RepositoryDependencies>();
        }
    }
}
