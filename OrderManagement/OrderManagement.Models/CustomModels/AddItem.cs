using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models.CustomModels
{
    public class AddItem
    {
        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Qty { get; set; }
    }
}
