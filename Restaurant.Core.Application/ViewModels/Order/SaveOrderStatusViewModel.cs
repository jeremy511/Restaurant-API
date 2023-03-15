
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Application.ViewModels.Table
{
    public class SaveOrderStatusViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Currency)]
        public string status { get; set; }

  

    
    }
}
