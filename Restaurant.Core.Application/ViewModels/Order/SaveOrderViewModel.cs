
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Application.ViewModels.Table
{
    public class SaveOrderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Currency)]
        public int TableId { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Currency)]
        public double SubTotal { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public string SelectedDish { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public int  OrderStatusId { get; set; }

    
    }
}
