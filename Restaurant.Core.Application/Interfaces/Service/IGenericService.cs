
namespace Restaurant.Core.Application.Interfaces.Service
{
    public interface IGenericService<SaveViewModel, ViewModel, Entity>
      where SaveViewModel : class
      where ViewModel : class
      where Entity : class

    {
        Task<SaveViewModel> AddAsync(SaveViewModel saveView);
        Task DeleteAsync(int Id);
        Task<List<ViewModel>> GetAllViewModel();
        Task<SaveViewModel> GetByIdSaveViewModel(int id);
        Task UpdateAsync(SaveViewModel saveView, int Id);
    }
}
