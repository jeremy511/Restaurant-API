using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Service;
using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Domain.Entities;
using AutoMapper;

namespace Restaurant.Core.Application.Services
{
    public class DishService : GenericService<SaveDishViewModel, DishViewModel, Dish>, IDishService
    {
        private readonly IDishRepository _repository;
        private readonly IIngredientRepository _ingredient;
        private readonly IMapper _mapper;

        public DishService(IDishRepository repository, IMapper mapper, IIngredientRepository ingredient) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _ingredient = ingredient;
            
        }

        public  async Task<List<DishViewModel>> GetAllViewModel()
        {
           
          
           var list = await _repository.GetAllWithIncludes(new List<string> { "DishCategory" });
            List<DishViewModel> result = list.Select(all => new DishViewModel
            {
                DishCategoryI = all.DishCategory.Name.ToString(), 
                Name = all.Name,    
                Id= all.Id,
                IngredientList = all.IngredientList,
                PeopleAmount = all.PeopleAmount,
                Price = all.Price,
            }).ToList();

            List<DishViewModel> ResultD = new();

            foreach (var item in result)
            {

                List<string> ingregients = new();
                string[] Ids = item.IngredientList.Split(",");
                foreach (var i in Ids)
                {
                    Ingredients viewModel = await _ingredient.GetViewModelById(Convert.ToInt32(i));
                    ingregients.Add(viewModel.Name);

                }

                string str = String.Join(",", ingregients);
                DishViewModel dishView = new();
                dishView.Id = item.Id;
                dishView.DishCategoryI = item.DishCategoryI;
                dishView.IngredientList = str;
                dishView.Price  = dishView.Price;
                dishView.PeopleAmount = dishView.PeopleAmount;
                dishView.Name = dishView.Name;
                ResultD.Add(dishView);



            }

            return ResultD;
        }

       
        public async Task<DishViewModel> GetId (int id)
        {

            var list = await _repository.GetAllWithIncludes(new List<string> { "DishCategory" });
            DishViewModel result = list.Where(i => i.Id == id).Select(all => new DishViewModel
            {
                DishCategoryI = all.DishCategory.Name.ToString(),
                Name = all.Name,
                Id = all.Id,
                IngredientList = all.IngredientList,
                PeopleAmount = all.PeopleAmount,
                Price = all.Price,
            }).FirstOrDefault();

            List<string> ingregients = new();
            string[] Ids = result.IngredientList.Split(",");
            foreach (var i in Ids)
            {
                Ingredients viewModel = await _ingredient.GetViewModelById(Convert.ToInt32(i));
                ingregients.Add(viewModel.Name);

            }
            string str = String.Join(",", ingregients);
            result.IngredientList = str;
            return result;
        }
    }
}
