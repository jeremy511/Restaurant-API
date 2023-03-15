


using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastucture.Persistence.Contexts;

namespace Restaurant.Infrastucture.Persistence.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredients>, IIngredientRepository
    {
        private readonly ApplicationContext _DbContext;

        public IngredientRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
