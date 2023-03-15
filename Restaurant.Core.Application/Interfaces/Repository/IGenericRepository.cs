using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Repository
{
    public interface IGenericRepository <Entity> where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);
        Task UpdateAsync(Entity entity, int id);
        Task DeleteAsync(Entity entity);
        Task<List<Entity>> GetAllViewModel();
        Task<Entity> GetViewModelById(int id);
        Task<List<Entity>> GetAllWithIncludes(List<string> properties);

    }
}
