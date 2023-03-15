

using Restaurant.Core.Domain.Common;

namespace Restaurant.Core.Domain.Entities
{
    public class Ingredients : AuditableBaseEntity
    {
        public string Name { get; set; }
    }
}
