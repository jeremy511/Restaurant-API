

using Restaurant.Core.Domain.Common;

namespace Restaurant.Core.Domain.Entities
{
    public class Table : AuditableBaseEntity
    {
        public int NumberPeopleItCanHold { get; set; }
        public string Description { get; set; }
        public int TableStatusId { get; set; }

        // Navegation Property
        public ICollection<Order> Order { get; set; } 
        public TableStatus TableStatus { get; set; }

    }
}


