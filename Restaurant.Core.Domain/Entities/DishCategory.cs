
namespace Restaurant.Core.Domain.Entities
{
    public class DishCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navegation Properties
       public ICollection<Dish> Dishes { get; set; }

    }
}
