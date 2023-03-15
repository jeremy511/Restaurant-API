
using System.ComponentModel.DataAnnotations;


namespace Restaurant.Core.Application.ViewModels.Table
{
    public class SaveDishCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ("*Obligado*"))]
        [DataType(DataType.Text)]
        public string Name { get; set; }


    }
}
