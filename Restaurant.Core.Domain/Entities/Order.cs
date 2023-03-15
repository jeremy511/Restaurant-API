
using Restaurant.Core.Domain.Common;

namespace Restaurant.Core.Domain.Entities
{
    public class Order : AuditableBaseEntity
    {
        public int TableId { get; set; }
        public double SubTotal { get; set; }
        public string SelectedDish { get; set; }
        public int OrderStatusId { get; set; }

        // Navegation Properties
        public Table Table { get; set; }
        public OrderStatus OrderStatus { get; set; }

        

    }
}


