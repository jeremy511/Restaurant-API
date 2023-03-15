
namespace Restaurant.Core.Application.ViewModels.Table
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public double SubTotal { get; set; }
        public string SelectedDish { get; set; }
        public string OrderStatusId { get; set; }
        public TableViewModel Table { get; set; }
    }
}
