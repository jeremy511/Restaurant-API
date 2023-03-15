


using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastucture.Persistence.Contexts;

namespace Restaurant.Infrastucture.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext _DbContext;

        public OrderRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
