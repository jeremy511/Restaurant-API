
using System.ComponentModel.DataAnnotations;


namespace Restaurant.Core.Application.ViewModels.Table
{
    public class SaveDishViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ("*Obligado*"))]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = ("*Obligado*"))]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required(ErrorMessage = ("*Obligado*"))]
        [DataType(DataType.Currency)]
        public int PeopleAmount { get; set; }

        [Required(ErrorMessage = ("*Obligado*"))]
        [DataType(DataType.Text)]
        public List<int> IngredientList { get; set; }

        [Required(ErrorMessage = ("*Obligado*"))]
        [DataType(DataType.Text)]
        public int DishCategoryId { get; set; }


    }
}
