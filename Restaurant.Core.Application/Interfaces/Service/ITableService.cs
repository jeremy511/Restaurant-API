using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Domain.Entities;


namespace Restaurant.Core.Application.Interfaces.Service
{
    public interface ITableService : IGenericService<SaveTableViewModel,TableViewModel,Table>
    {
    }
}
