

namespace Restaurant.Core.Application.ViewModels.Table
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PeopleAmount { get; set; }
        public string IngredientList { get; set; }
        public string DishCategoryI{ get; set; }
    }
}
