using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models.CustomModels
{
    public class LoginModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Minimum 5 Characters are Required.")]
        [MaxLength(10, ErrorMessage = "Maximum Limit is 10 Characters")]
        public string Username { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Minimum 5 Characters are Required.")]
        [MaxLength(10, ErrorMessage = "Maximum Limit is 10 Characters")]
        public string Password { get; set; }

        public int id { get; set; }
    }
}
