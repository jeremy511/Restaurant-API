
using Restaurant.Core.Application.Interfaces.Service;
using Restaurant.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Restaurant.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            service.AddTransient<IDishService, DishService > ();
            service.AddTransient<ITableService, TableService>();
            service.AddTransient<IOrderService, OrderService>();
            service.AddTransient<ITableStatusService, TableStatusService>();
            service.AddTransient<IDishCategoryService, DishCategoryService>();

            service.AddTransient<IIngredientsService, IngredientsService>();
 

        }
    }
}
