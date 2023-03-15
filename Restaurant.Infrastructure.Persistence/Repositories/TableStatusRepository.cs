


using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastucture.Persistence.Contexts;

namespace Restaurant.Infrastucture.Persistence.Repositories
{
    public class TableStatusRepository : GenericRepository<TableStatus>, ITableStatusRepository
    {
        private readonly ApplicationContext _DbContext;

        public TableStatusRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
