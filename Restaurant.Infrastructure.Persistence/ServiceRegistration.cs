
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Infrastucture.Persistence.Contexts;
using Restaurant.Infrastucture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Infrastucture.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfratructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Context Configuration"

                if (configuration.GetValue<bool>("UseInMemoryDatabase"))
                {
                    services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("InMemoryDB"));
                }
                else
                {
                    services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
                }
            #endregion

            #region "Service"
                 services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                 services.AddTransient<IDishRepository, DishRepository>();
                 services.AddTransient<IOrderRepository, OrderRepository>();
                 services.AddTransient<ITableRepository, TableRepository>();
                 services.AddTransient<ITableStatusRepository, TableStatusRepository>();
                 services.AddTransient<IOrderStatusRepository, OrderStatusRepository>();
                 services.AddTransient<IDishCategoryRepository, DishCategoryRepository>();

            services.AddTransient<IIngredientRepository, IngredientRepository>();

            #endregion
        }
    }
}
