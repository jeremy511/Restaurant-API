


using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastucture.Persistence.Contexts;

namespace Restaurant.Infrastucture.Persistence.Repositories
{
    public class DishCategoryRepository : GenericRepository<DishCategory>, IDishCategoryRepository
    {
        private readonly ApplicationContext _DbContext;

        public DishCategoryRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
