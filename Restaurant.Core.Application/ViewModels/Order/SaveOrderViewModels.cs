
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Application.ViewModels.Table
{
    public class SaveOrderViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Currency)]
        public int TableId { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Currency)]
        public double SubTotal { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        
        public List<int> SelectedDish { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public int  OrderStatusId { get; set; }

    
    }
}
