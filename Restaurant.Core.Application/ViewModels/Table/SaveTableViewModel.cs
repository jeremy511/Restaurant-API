using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Table
{
    public class SaveTableViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Currency)]
        public int NumberPeopleItCanHold { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public int TableStatusId { get; set; }


    }
}
