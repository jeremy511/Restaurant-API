using Restaurant.Core.Domain.Common;


namespace Restaurant.Core.Domain.Entities
{
    public class Dish : AuditableBaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int PeopleAmount { get; set; }
        public string IngredientList { get; set; }
        public int DishCategoryId { get; set; }


        // Navegation Property
        public DishCategory DishCategory { get; set; }
        


    }

}