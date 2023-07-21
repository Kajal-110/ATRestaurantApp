using OrderManagement.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repositories.Repos
{
    public interface IAuthService
    {
        LoginModel Login(LoginModel loginModel);
    }
}
