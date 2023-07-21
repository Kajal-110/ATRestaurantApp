using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models.CustomModels
{
    public class Order
    {
        public List<OrderItem> orderItems { get; set; }
        public AddItem AddItem { get; set; }

        public int total { get; set; }

        public int totalItem { get; set; }

        public int totalPayable { get; set; }

        public int netPayable { get; set; }
        public int couponId { get; set; }

        [Required]
        public string couponCode { get; set; }
    }
}
