

namespace Restaurant.Core.Application.ViewModels.Table
{
    public class TableViewModel
    {
        public int Id { get; set; }
        public int NumberPeopleItCanHold { get; set; }
        public string Description { get; set; }
        public string TableStatusId { get; set; }

        public ICollection<OrderViewModel> Order { get; set; }

    }
}
