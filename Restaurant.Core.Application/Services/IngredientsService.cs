using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Service;
using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Domain.Entities;
using AutoMapper;

namespace Restaurant.Core.Application.Services
{
    public class IngredientsService : GenericService<SaveIngredientViewModel, IngredientViewModel, Ingredients>, IIngredientsService
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;

        public IngredientsService(IIngredientRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
