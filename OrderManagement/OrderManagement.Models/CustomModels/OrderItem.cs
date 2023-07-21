using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models.CustomModels
{
    public class OrderItem
    {
        public string Name { get; set; }
        public int id { get; set; }
        public int qty { get; set; }
        public int amount { get; set; }
        public int total { get; set; }
    }
}
