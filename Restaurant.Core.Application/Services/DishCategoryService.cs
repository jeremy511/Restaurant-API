using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Service;
using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Domain.Entities;
using AutoMapper;

namespace Restaurant.Core.Application.Services
{
    public class DishCategoryService : GenericService<SaveDishCategoryViewModel, DishCategoryViewModel, DishCategory>, IDishCategoryService
    {
        private readonly IDishCategoryRepository _repository;
        private readonly IMapper _mapper;

        public DishCategoryService(IDishCategoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
