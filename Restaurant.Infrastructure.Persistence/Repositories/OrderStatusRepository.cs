


using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastucture.Persistence.Contexts;

namespace Restaurant.Infrastucture.Persistence.Repositories
{
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IOrderStatusRepository
    {
        private readonly ApplicationContext _DbContext;

        public OrderStatusRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
