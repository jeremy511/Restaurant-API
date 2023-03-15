using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Domain.Entities;


namespace Restaurant.Core.Application.Interfaces.Service
{
    public interface IOrderService : IGenericService<SaveOrderViewModel,OrderViewModel,Order>
    {
        Task<List<OrderViewModel>> GetTableOrders(int tableId);
        Task<OrderViewModel> GetId(int id);
    }
}
