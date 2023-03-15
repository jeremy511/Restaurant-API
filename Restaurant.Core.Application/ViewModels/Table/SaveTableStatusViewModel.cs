using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Table
{
    public class SaveTableStatusViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Currency)]
        public string status { get; set; }


    }
}
