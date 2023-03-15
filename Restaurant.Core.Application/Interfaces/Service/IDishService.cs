using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Domain.Entities;


namespace Restaurant.Core.Application.Interfaces.Service
{
    public interface IDishService : IGenericService<SaveDishViewModel, DishViewModel, Dish>
    {
        Task<DishViewModel> GetId(int id);
    }
}
