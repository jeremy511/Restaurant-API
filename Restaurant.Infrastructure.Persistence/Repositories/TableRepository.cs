
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastucture.Persistence.Contexts;

namespace Restaurant.Infrastucture.Persistence.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly ApplicationContext _DbContext;

        public TableRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
