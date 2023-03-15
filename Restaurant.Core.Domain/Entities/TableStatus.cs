using Restaurant.Core.Domain.Common;


namespace Restaurant.Core.Domain.Entities
{
    public class TableStatus : Status
    {
       public ICollection<Table> Tables { get; set; }

    }
}
