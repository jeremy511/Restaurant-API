using Restaurant.Core.Domain.Common;


namespace Restaurant.Core.Domain.Entities
{
    public class OrderStatus : Status
    {
        public ICollection<Order> Orders  { get; set; }
    }
}
