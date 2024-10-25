using Main.Application.Factory;
using Main.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Main.Application.DendencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // SqlServer
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);

            // MongoDB
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IMongoUnitOfWork, MongoUnitOfWork>();
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
